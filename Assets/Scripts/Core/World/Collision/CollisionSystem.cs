using System.Collections.Generic;
using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Ufo;
using Asteroids.Core.Actors.Player;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Entities.State.Objects;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;
using UnityEngine;

namespace Asteroids.Core.World.Collision {
    [UsedImplicitly]
    public class CollisionSystem : System<CollisionState>, ICollisionSystem, IFixedUpdateSystem {
        // Events

        private EnemyHitEvent enemyHitEventPublisher;
        private PlayerHitEvent playerHitEventPublisher;

        // Active entities
        private ActiveEntities ActiveEntities { get; }

        public CollisionSystem(CollisionState state, EntitiesState entities, GameState game) : base(state) {
            ActiveEntities = entities.Active;

            State.RegisterEnemyHitPublisher(out enemyHitEventPublisher);
            State.RegisterPlayerHitPublisher(out playerHitEventPublisher);

            RegisterSystemActivityFlag(game.LevelActiveFlag);
        }

        protected override void OnDisableSystem() {
            Reset();
        }

        // todo-consider: maybe use specified predicates (strategy pattern) to encapsulate the collision logic for each entity ?
        public void FixedUpdateSystem(float fixedDeltaTime) {
            using IEnumerator<ICollider> asteroids = ActiveEntities.GetConcrete<Asteroid>().GetEnumerator();
            using IEnumerator<ICollider> ufosEnum = ActiveEntities.GetConcrete<Ufo>().GetEnumerator();

            do {
                ICollider enemy = null;
                if (asteroids.MoveNext()) enemy = asteroids.Current;
                else if (ufosEnum.MoveNext()) enemy = ufosEnum.Current;
                if (enemy == null) break;

                // if the player hits enemy - stop player collision calculations
                // - to prevent concurrent hits (when enemy and player are destroyed at the same time)
                // - to prevet collection changes when enumerator is processing
                bool breakLoop = false;

                // Check bullets
                foreach (ICollider ammo in ActiveEntities.GetConcrete<Bullet>()) {
                    if (IsIntersect(enemy, ammo)) {
                        enemyHitEventPublisher(enemy, ammo);
                        breakLoop = true;
                        break;
                    }
                }
                if (breakLoop) break;

                // Check laser
                foreach (Laser laser in ActiveEntities.GetConcrete<Laser>()) {
                    float enemyDistance = Vector2.Distance(enemy.Pos, laser.Pos);
                    // Check laser distance limit
                    if (laser.MaxDistance + laser.ColliderRadius < enemyDistance - enemy.ColliderRadius) continue;
                    // Find nearest laser point to enemy
                    Vector2 laserNearestPoint = laser.Pos + laser.Direction * enemyDistance;

                    float distance = Vector2.Distance(enemy.Pos, laserNearestPoint);
                    float collisionDistance = laser.ColliderRadius + enemy.ColliderRadius;
                    if (distance <= collisionDistance) {
                        enemyHitEventPublisher(enemy, laser);
                        breakLoop = true;
                        // Don't break here (for laser) - it may hit multiple enemies at once
                    }
                }
                if (breakLoop) break;

                // Check player (latest, after weapons ammo)
                foreach (Player player in ActiveEntities.GetConcrete<Player>()) {
                    if (IsIntersect(enemy, player)) {
                        playerHitEventPublisher(player, enemy);
                        breakLoop = true;
                        break;
                    }
                }
                if (breakLoop) break;

            } while (true);
        }

        private bool IsIntersect(ICollider collider1, ICollider collider2) {
            return Vector2.Distance(collider1.Pos, collider2.Pos) < collider1.ColliderRadius + collider2.ColliderRadius;
        }

    }

}