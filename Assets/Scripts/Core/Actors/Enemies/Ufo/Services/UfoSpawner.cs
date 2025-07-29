using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Services.Spawner;
using JetBrains.Annotations;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo.Services {
    [UsedImplicitly]
    public class UfoSpawner : PoolableEntitySpawner<Ufo, UfoFactory> {

        public UfoSpawner(UfoFactory factory) : base(factory) { }

        public Ufo Spawn(Vector3 position, Vector3 direction, EntityBase huntTarget) {
            Ufo ufo = SpawnInternal();
            ufo.Init(position, direction);

            // todo-later: maybe move "SetTarget" from spawn to start hunting
            ufo.SetTarget(huntTarget);

            return ufo;
        }


    }

}