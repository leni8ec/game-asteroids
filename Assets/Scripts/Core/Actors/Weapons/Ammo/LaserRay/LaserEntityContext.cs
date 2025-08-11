using Asteroids.Core.Actors.Common.Context;
using Asteroids.Core.Actors.Common.Services.Factory;
using Asteroids.Core.Actors.Common.Services.Spawner;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using UnityEngine;

// ReSharper disable ClassNeverInstantiated.Global
namespace Asteroids.Core.Actors.Weapons.Ammo.LaserRay {

    public class LaserFactory : EntityFactory<Laser, LaserRayView, LaserRayState, LaserConfig> {
        public LaserFactory(LaserConfig config) : base(config) { }
    }

    public class LaserSpawner : PoolableEntitySpawner<Laser, LaserFactory> {
        public LaserSpawner(LaserFactory factory) : base(factory) { }

        public Laser Spawn(Vector3 position, Vector3 direction) {
            Laser laser = SpawnInternal();
            laser.Set(position, direction);
            laser.Emit();
            return laser;
        }
    }

    public class LaserEntityContext : BaseEntityContext<Laser, LaserFactory, LaserSpawner> { }

}