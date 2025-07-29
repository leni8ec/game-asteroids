using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Asteroid.Services;
using Asteroids.Core.World.Common.Values;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;
using UnityEngine;

namespace Asteroids.Core.World.Enemies.Asteroids {
    [UsedImplicitly]
    public class AsteroidKillSystem : SystemBase, IAsteroidKillSystem {

        private IReactiveProperty<GameStatus> GameStatus { get; }
        private EntitiesState EntitiesState { get; }
        private AsteroidSpawner AsteroidSpawner { get; }

        public AsteroidKillSystem(GameState gameState, EntitiesState entitiesState, AsteroidSpawner asteroidSpawner) {
            GameStatus = gameState.Status;
            EntitiesState = entitiesState;
            AsteroidSpawner = asteroidSpawner;

            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        protected override void OnEnableSystem() {
            EntitiesState.KillEvent += KillEventHandler;
        }

        protected override void OnDisableSystem() {
            EntitiesState.KillEvent -= KillEventHandler;
        }

        private void KillEventHandler(IEntity entity) {
            if (entity is Asteroid asteroid) OnAsteroidKill(asteroid);
        }

        private void OnAsteroidKill(Asteroid killedAsteroid) {
            // Split only large asteroids
            if (killedAsteroid.Size is not AsteroidSize.Large)
                return;

            SplitAsteroid(killedAsteroid);
        }

        /// Split asteroid into smaller fragments
        private void SplitAsteroid(Asteroid asteroid) {
            AsteroidSize size = asteroid.Size.NextSmallerSize();
            Vector3 direction = Random.insideUnitCircle;
            float degreesDelta = 360f / asteroid.DestroyedFragments;
            for (int i = 0; i < asteroid.DestroyedFragments; i++) {
                direction = Quaternion.AngleAxis(degreesDelta, Vector3.forward) * direction;
                Vector3 position = asteroid.Position + direction * 0.5f;
                AsteroidSpawner.Spawn(position, direction, size);
            }
        }
    }
}