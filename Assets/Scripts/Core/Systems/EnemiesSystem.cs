﻿using System.Collections.Generic;
using Core.Framework.Systems;
using Core.Systems.Interface;
using JetBrains.Annotations;
using Model.Adapters;
using Model.Data.EntityPool;
using Model.Data.Reactive;
using Model.Data.State;
using Model.Data.Unity.Config;
using Model.Entity;
using Model.Entity.Interface;
using Model.Game;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Core.Systems {
    [UsedImplicitly]
    public class EnemiesSystem : SystemBase, IEnemiesSystem, IUpdateSystem {
        private WorldConfig WorldConfig { get; }
        private EnemiesSystemState State { get; }

        private Player Player { get; }
        private ICameraAdapter Camera { get; }

        private EntitiesManager<Ufo, UfoState, UfoConfig> UfosManager { get; }
        private Dictionary<AsteroidConfig.Size, EntitiesManager<Asteroid, AsteroidState, AsteroidConfig>> AsteroidsManagers { get; }

        private IEntitiesList<Ufo> ActiveUfos { get; }
        private Dictionary<AsteroidConfig.Size, IEntitiesList<Asteroid>> ActiveAsteroidsDict { get; }


        private IReactiveProperty<GameStatus> GameStatus { get; }

        public EnemiesSystem(WorldConfig worldConfig, EnemiesSystemState state,
            ActiveEntitiesState activeEntities, EntitiesManagersState entitiesManagers, GameSystemState gameSystemState, ICameraAdapter cameraAdapter) {

            WorldConfig = worldConfig;
            State = state;

            // Link properties
            Camera = cameraAdapter;
            Player = activeEntities.player;

            UfosManager = entitiesManagers.ufos;
            AsteroidsManagers = entitiesManagers.asteroidsManagers;

            ActiveUfos = activeEntities.ufos;
            ActiveAsteroidsDict = activeEntities.asteroidsDict;

            GameStatus = gameSystemState.Status;

            // Subscribe
            CollisionSystem.EnemyHitEvent += EnemyHitHandler;
            Asteroid.ExplosionEvent += AsteroidExplosionHandler;

            // Game state events
            GameStateSystem.NewGameEvent += Play;
            GameStateSystem.GameOverEvent += Reset;
        }

        private void Play() {
            Enable();

            State.asteroidSpawnCountdown = 1 / WorldConfig.asteroidsSpawnRate;
            State.ufoSpawnCountdown = 1 / WorldConfig.ufoSpawnRate;
        }

        private void Reset() {
            Disable();
            State.Reset();

            ActiveUfos.ForEachSave(Destroy);
            foreach (IEntitiesList<Asteroid> activeAsteroids in ActiveAsteroidsDict.Values)
                activeAsteroids.ForEachSave(Destroy);

            return;
            void Destroy(IEntity entity) => entity.Destroy();
        }

        public void Upd(float deltaTime) {
            // Spawn
            if ((State.asteroidSpawnCountdown -= deltaTime) <= 0) {
                // Check asteroids count limit
                int totalActiveAsteroids = ActiveAsteroidsDict[AsteroidConfig.Size.Large].Count
                                           + ActiveAsteroidsDict[AsteroidConfig.Size.Medium].Count
                                           + ActiveAsteroidsDict[AsteroidConfig.Size.Small].Count;
                if (totalActiveAsteroids < WorldConfig.asteroidsLimit) {
                    State.asteroidSpawnCountdown = 1 / WorldConfig.asteroidsSpawnRate;
                    SpawnAsteroid();
                }
            }

            if ((State.ufoSpawnCountdown -= deltaTime) <= 0) {
                int totalActiveUfo = ActiveUfos.Count;
                if (totalActiveUfo < WorldConfig.ufosLimit) {
                    State.ufoSpawnCountdown = 1 / WorldConfig.ufoSpawnRate;
                    SpawnUfo();
                }
            }

        }


        private void SpawnAsteroid() {
            Asteroid asteroid = AsteroidsManagers[AsteroidConfig.Size.Large].TakeEntity();
            Vector3 spawnPoint = GetRandomSpawnPoint();
            Vector3 direction = GetRandomDirection(spawnPoint);
            asteroid.Init(spawnPoint, direction);
        }

        private void SpawnUfo() {
            Ufo ufo = UfosManager.TakeEntity();
            Vector3 spawnPoint = GetRandomSpawnPoint();
            Vector3 direction = GetRandomDirection(spawnPoint);
            ufo.Init(spawnPoint, direction);
            ufo.SetTarget(Player);
        }


        private Vector3 GetRandomSpawnPoint() {
            Rect worldBorders = Camera.GetWorldLimits(WorldConfig.screenSpawnOutsideOffset);

            Vector2 vector = new(Random.value, Random.value);
            Vector2 pos = new(worldBorders.x + worldBorders.width * vector.x, worldBorders.y + worldBorders.height * vector.y);

            Vector3 worldPoint;
            if (Random.value >= 0.5f)
                worldPoint = new Vector3(vector.x < 0.5f ? worldBorders.x : worldBorders.xMax, pos.y); // left/right
            else
                worldPoint = new Vector3(pos.x, vector.y < 0.5f ? worldBorders.y : worldBorders.yMax); // top/bottom

            return worldPoint;
        }

        private Vector3 GetRandomDirection(Vector3 spawnPoint) {
            float randomAngle = (Random.value - 0.5f) * 90f;
            Vector2 direction = -spawnPoint.normalized;
            direction = Quaternion.AngleAxis(randomAngle, Vector3.forward) * direction;

            return direction;
        }

        private void EnemyHitHandler(ICollider enemy, ICollider ammo) {
            if (ammo is Bullet bullet) bullet.Destroy();
            switch (enemy) {
                case Asteroid asteroid:
                    asteroid.Destroy();
                    break;
                case Ufo ufo:
                    ufo.Destroy();
                    break;
            }
        }

        private void AsteroidExplosionHandler(Asteroid destroyedAsteroid) {
            if (GameStatus.Value != Model.Game.GameStatus.Playing) return; // hack

            if (destroyedAsteroid.Size == AsteroidConfig.Size.Medium) return; // Don't split medium asteroids
            if (destroyedAsteroid.Size == AsteroidConfig.Size.Small) return;

            AsteroidConfig.Size targetSize = destroyedAsteroid.Size;
            if (destroyedAsteroid.Size == AsteroidConfig.Size.Large) targetSize = AsteroidConfig.Size.Medium;
            else if (destroyedAsteroid.Size == AsteroidConfig.Size.Medium) targetSize = AsteroidConfig.Size.Small;

            Vector3 direction = Random.insideUnitCircle;
            float degreesDelta = 360f / destroyedAsteroid.DestroyedFragments;
            for (int i = 0; i < destroyedAsteroid.DestroyedFragments; i++) {
                Asteroid newAsteroid = AsteroidsManagers[targetSize].TakeEntity();
                direction = Quaternion.AngleAxis(degreesDelta, Vector3.forward) * direction;
                Vector3 spawnPoint = destroyedAsteroid.Position + direction * 0.5f;
                newAsteroid.Init(spawnPoint, direction);
            }
        }

    }
}