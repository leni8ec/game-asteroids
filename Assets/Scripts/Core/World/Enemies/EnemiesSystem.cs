using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Asteroid.Services;
using Asteroids.Core.Actors.Enemies.Ufo;
using Asteroids.Core.Actors.Enemies.Ufo.Services;
using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Camera;
using Asteroids.Core.World.Common.Config;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Services.Spawner.Extra;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Asteroids.Core.World.Enemies {
    // todo-consider: use 'Strategy' to encapsulate spawn logic
    [UsedImplicitly]
    public class EnemiesSystem : SystemBase, IEnemiesSystem, IUpdateSystem {
        private LevelConfig LevelConfig { get; }
        public ScreenConfig ScreenConfig { get; }
        private EnemiesState State { get; }
        private EntitiesState Entities { get; }

        private ICameraAdapter Camera { get; }

        private UfoSpawner UfoSpawner { get; }
        private AsteroidSpawner AsteroidSpawner { get; }

        private IReadOnlyDynamicList<IEntity> ActiveUfos { get; }
        private IReadOnlyDynamicList<IEntity> ActiveAsteroids { get; }

        private Player player;

        public EnemiesSystem(LevelConfig levelConfig, ScreenConfig screenConfig, EnemiesState state,
            EntitiesState entities, GameState gameState, ICameraAdapter cameraAdapter,
            UfoSpawner ufoSpawner, AsteroidSpawner asteroidSpawner) {

            LevelConfig = levelConfig;
            ScreenConfig = screenConfig;
            State = state;
            Entities = entities;

            // Link properties
            Camera = cameraAdapter;

            UfoSpawner = ufoSpawner;
            AsteroidSpawner = asteroidSpawner;

            ActiveUfos = entities.Active.Get<Ufo>();
            ActiveAsteroids = entities.Active.Get<Asteroid>();

            // Game state events
            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }


        protected override void OnEnableSystem() {
            State.AsteroidSpawnCountdown = 1 / LevelConfig.AsteroidsSpawnRate;
            State.UfoSpawnCountdown = 1 / LevelConfig.UfoSpawnRate;
            player = Entities.Player;

        }

        protected override void OnDisableSystem() {
            State.Reset();
            player = null;
        }


        public void UpdateSystem(float deltaTime) {
            // Spawn
            if ((State.AsteroidSpawnCountdown -= deltaTime) <= 0) {
                // Check asteroids count limit
                int totalActiveAsteroids = ActiveAsteroids.Count;
                if (totalActiveAsteroids < LevelConfig.AsteroidsLimit) {
                    State.AsteroidSpawnCountdown = 1 / LevelConfig.AsteroidsSpawnRate;
                    SpawnAsteroid();
                }
            }

            if ((State.UfoSpawnCountdown -= deltaTime) <= 0) {
                int totalActiveUfo = ActiveUfos.Count;
                if (totalActiveUfo < LevelConfig.UfosLimit) {
                    State.UfoSpawnCountdown = 1 / LevelConfig.UfoSpawnRate;
                    SpawnUfo();
                }
            }
        }


        private void SpawnAsteroid() {
            Vector3 position = GetRandomSpawnPosition();
            Vector3 direction = GetRandomDirection(position);
            AsteroidSpawner.Spawn(position, direction);
        }

        private void SpawnUfo() {
            Vector3 position = GetRandomSpawnPosition();
            Vector3 direction = GetRandomDirection(position);
            UfoSpawner.Spawn(position, direction, player);
        }


        private Vector3 GetRandomSpawnPosition() {
            Rect worldBorders = Camera.GetWorldLimits(ScreenConfig.ScreenSpawnOutsideOffset);

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

    }
}