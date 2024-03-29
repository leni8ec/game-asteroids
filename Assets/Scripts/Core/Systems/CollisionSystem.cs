﻿using System.Collections.Generic;
using Core.Framework.Systems;
using Core.Systems.Interface;
using JetBrains.Annotations;
using Model.Data.State;
using Model.Data.Unity.Config;
using Model.Entity;
using Model.Entity.Interface;
using UnityEngine;

namespace Core.Systems {
    [UsedImplicitly]
    public class CollisionSystem : SystemBase, ICollisionSystem, IUpdateSystem {
        private ActiveEntitiesState Entities { get; }

        // Events
        public delegate void PlayerHitEventHandler(ICollider enemy);
        public delegate void EnemyHitEventHandler(ICollider enemy, ICollider ammo);

        public static event PlayerHitEventHandler PlayerHitEvent;
        public static event EnemyHitEventHandler EnemyHitEvent;


        public CollisionSystem(ActiveEntitiesState entities) {
            Entities = entities;

            // Game state events
            GameStateSystem.NewGameEvent += Enable;
            GameStateSystem.GameOverEvent += Disable;
        }

        public void Upd(float deltaTime) {
            using IEnumerator<Asteroid> asteroidsLargeEnum = Entities.asteroidsDict[AsteroidConfig.Size.Large].GetEnumerator();
            using IEnumerator<Asteroid> asteroidsMediumEnum = Entities.asteroidsDict[AsteroidConfig.Size.Medium].GetEnumerator();
            using IEnumerator<Asteroid> asteroidsSmallEnum = Entities.asteroidsDict[AsteroidConfig.Size.Small].GetEnumerator();
            using IEnumerator<Ufo> ufosEnum = Entities.ufos.GetEnumerator();

            do {
                ICollider enemy;
                if (asteroidsLargeEnum.MoveNext()) enemy = asteroidsLargeEnum.Current;
                else if (asteroidsMediumEnum.MoveNext()) enemy = asteroidsMediumEnum.Current;
                else if (asteroidsSmallEnum.MoveNext()) enemy = asteroidsSmallEnum.Current;
                else if (ufosEnum.MoveNext()) enemy = ufosEnum.Current;
                else break;
                if (enemy == null) break;

                // Check bullets
                bool toBreak = false;
                foreach (ICollider ammo in Entities.ammo1) {
                    if (IsIntersect(enemy, ammo)) {
                        EnemyHitEvent?.Invoke(enemy, ammo);
                        toBreak = true;
                        break;
                    }
                }
                if (toBreak) break;

                // Check laser
                foreach (Laser laser in Entities.ammo2) {
                    float enemyDistance = Vector2.Distance(enemy.Pos, laser.Pos);
                    // Check laser distance limit
                    if (laser.MaxDistance + laser.ColliderRadius < enemyDistance - enemy.ColliderRadius) continue;
                    // Find nearest laser point to enemy
                    Vector2 laserNearestPoint = laser.Pos + laser.Direction * enemyDistance;

                    float distance = Vector2.Distance(enemy.Pos, laserNearestPoint);
                    float collisionDistance = laser.ColliderRadius + enemy.ColliderRadius;
                    if (distance <= collisionDistance) {
                        EnemyHitEvent?.Invoke(enemy, laser);
                        toBreak = true;
                        // Don't break here (for laser)
                    }
                }
                if (toBreak) break;

                // Check player (latest, after bullets)
                if (IsIntersect(enemy, Entities.player)) {
                    PlayerHitEvent?.Invoke(enemy);
                    break;
                }

            } while (true);
        }

        private bool IsIntersect(ICollider collider1, ICollider collider2) {
            return Vector2.Distance(collider1.Pos, collider2.Pos) < collider1.ColliderRadius + collider2.ColliderRadius;
        }
    }
}