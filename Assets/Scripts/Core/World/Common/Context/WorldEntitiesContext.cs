using Asteroids.Core.Actors.Enemies.Asteroid.Services;
using Asteroids.Core.Actors.Enemies.Ufo.Services;
using Asteroids.Core.Actors.Player.Services;
using Asteroids.Core.Actors.Weapons.Ammo.Bullet;
using Asteroids.Core.Actors.Weapons.Ammo.LaserRay;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Core.World.Common.Context {
    internal class WorldEntitiesContext : IDependencyContext {

        public void InstallTo(IDependencyContainer container) {
            new AsteroidEntityContext().InstallTo(container);
            new UfoEntityContext().InstallTo(container);
            new BulletEntityContext().InstallTo(container);
            new LaserEntityContext().InstallTo(container);
            new PlayerEntityContext().InstallTo(container);
        }

    }
}