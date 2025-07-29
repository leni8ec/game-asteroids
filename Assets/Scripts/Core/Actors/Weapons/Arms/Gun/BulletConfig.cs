using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Arms.Gun {
    // todo: split config to Arms and Ammo
    [CreateAssetMenu(menuName = "Configs/Bullet Config")]
    public class BulletConfig : EntityConfig, IColliderRadiusContainer {
        [Space]
        [Tooltip("shots per sec")]
        public float fireRate = 5;
        [Space]
        public float speed = 5;
        [Tooltip("in sec")]
        public float lifetime = 2;

        [Header("Collision")]
        public float colliderRadius = 0.1f;
        public float ColliderRadius => colliderRadius;

    }

}