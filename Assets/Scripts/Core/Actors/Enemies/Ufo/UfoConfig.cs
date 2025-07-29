using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    [CreateAssetMenu(menuName = "Configs/Ufo Config")]
    public class UfoConfig : EntityConfig, IColliderRadiusContainer {
        [Space]
        public float startSpeed = 1;
        public float huntSpeed = 1.2f;

        [Tooltip("in seconds")]
        public float huntDelay = 3;

        [Header("Collision")]
        public float colliderRadius = 0.1f;
        public float ColliderRadius => colliderRadius;

    }
}