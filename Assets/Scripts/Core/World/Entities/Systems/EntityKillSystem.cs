using Asteroids.Core.Actors.Player;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.World.Collision;
using Asteroids.Core.World.Entities.State;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Entities.Systems {
    [UsedImplicitly]
    public class EntityKillSystem : SystemBase, IEntityKillSystem {
        private readonly EntityKillEvent killEventPublisher;

        public EntityKillSystem(CollisionState collision, EntitiesState entities) {

            collision.EnemyHitEvent += EnemyHitEventHandler;
            collision.PlayerHitEvent += PlayerHitEventHandler;

            entities.RegisterEntityKillPublisher(out killEventPublisher);
        }

        private void EnemyHitEventHandler(IEntity enemy, IEntity ammo) {
            // Kill weapons ammo on hit (only bullets, not laser)
            if (ammo is Bullet bullet)
                KillEntity(bullet);

            // Kill any enemy on hit
            KillEntity(enemy);
        }

        private void PlayerHitEventHandler(IPlayer player, IEntity source) {
            KillEntity(player);
        }

        private void KillEntity(IEntity entity) {
            // 1. Kill event
            killEventPublisher(entity);
            // 2. Despawn entity
            entity.Kill();
        }

    }
}