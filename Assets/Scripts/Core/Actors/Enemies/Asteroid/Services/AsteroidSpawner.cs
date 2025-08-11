using Asteroids.Core.Actors.Common.Services.Spawner;
using JetBrains.Annotations;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Asteroid.Services {
    [UsedImplicitly]
    public class AsteroidSpawner : PoolableBunchEntitySpawner<Asteroid, AsteroidFactory, AsteroidSize> {

        public AsteroidSpawner(AsteroidFactory factory) : base(factory) { }

        /// Spawn large Asteroid by default
        public Asteroid Spawn(Vector3 position, Vector3 direction, AsteroidSize size = AsteroidSize.Large) {
            Asteroid asteroid = SpawnInternal(size);
            asteroid.Init(position, direction);
            return asteroid;
        }

    }
}