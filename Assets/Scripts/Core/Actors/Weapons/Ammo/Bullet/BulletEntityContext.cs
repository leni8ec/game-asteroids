using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Framework.Entity.Context;
using Asteroids.Framework.Entity.Services.Factory;
using Asteroids.Framework.Entity.Services.Spawner;
using UnityEngine;

// ReSharper disable ClassNeverInstantiated.Global
namespace Asteroids.Core.Actors.Weapons.Ammo.Bullet {

    public class BulletFactory : EntityFactory<Arms.Gun.Bullet, BulletView, BulletState, BulletConfig> {
        public BulletFactory(BulletConfig config) : base(config) { }
    }

    public class BulletSpawner : PoolableEntitySpawner<Arms.Gun.Bullet, BulletFactory> {
        public BulletSpawner(BulletFactory factory) : base(factory) { }

        public Arms.Gun.Bullet Spawn(Vector3 position, Vector3 direction) {
            Arms.Gun.Bullet bullet = SpawnInternal();
            bullet.Set(position, direction);
            bullet.Emit();
            return bullet;
        }
    }


    public class BulletEntityContext : BaseEntityContext<Arms.Gun.Bullet, BulletFactory, BulletSpawner> { }

}