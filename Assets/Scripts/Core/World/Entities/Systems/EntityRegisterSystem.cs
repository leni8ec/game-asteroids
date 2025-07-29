using Asteroids.Core.Actors.Enemies.Asteroid.Services;
using Asteroids.Core.Actors.Enemies.Ufo.Services;
using Asteroids.Core.Actors.Player.Services;
using Asteroids.Core.Actors.Weapons.Ammo.Bullet;
using Asteroids.Core.Actors.Weapons.Ammo.LaserRay;
using Asteroids.Core.World.Entities.State;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Entities.Systems {
    // todo-later: find more reliable solution
    // .
    // How to get active elements without having a ton of dependencies?
    // .
    // As an option - in spawners themselves, add active objects to the state?
    // But I would like to keep them in order (although this can be done by sorting when adding)
    [UsedImplicitly]
    public class EntityActiveRegisterSystem : SystemBase, IEntityActiveRegisterSystem {

        public EntityActiveRegisterSystem(EntitiesState entities,
            PlayerSpawner playerSpawner,
            UfoSpawner ufoSpawner, AsteroidSpawner asteroidSpawner,
            BulletSpawner bulletSpawner, LaserSpawner laserSpawner
        ) {
            // 1. Player
            entities.Active.Add(playerSpawner.ActiveEntities);

            // 2. Enemies
            entities.Active.Add(ufoSpawner.ActiveEntities);
            entities.Active.Add(asteroidSpawner.ActiveEntities);

            // 3. Ammo
            entities.Active.Add(bulletSpawner.ActiveEntities);
            entities.Active.Add(laserSpawner.ActiveEntities);
        }

    }
}