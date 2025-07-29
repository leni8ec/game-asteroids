using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Arms.Laser {
    // todo: split config to Arms and Ammo
    [CreateAssetMenu(menuName = "Configs/Laser Config")]
    public class LaserConfig : EntityConfig, IColliderRadiusContainer {
        [Space]
        [Tooltip("Max shots count")]
        public int maxShotsCount = 3;
        [Tooltip("Delay to restore shot")]
        public float shotRefillDuration = 3;
        [Space]
        [Tooltip("shots per sec")]
        public float fireRate = 1f;
        [Space]
        public float maxDistance = 8;
        [Space]
        [Tooltip("lifetime")]
        public float duration = 1f;

        [Header("Collision")]
        public float colliderRadius = 0.05f;
        public float ColliderRadius => colliderRadius;

    }
}