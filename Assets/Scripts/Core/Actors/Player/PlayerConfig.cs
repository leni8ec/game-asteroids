using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {
    [CreateAssetMenu(menuName = "Configs/Player Config")]
    public class PlayerConfig : EntityConfig, IColliderRadiusContainer {
        [Space]
        public float speed = 3f;
        [Tooltip("in sec to full speed")]
        public float accelerationInertia = 0.5f;
        public float brakingInertia = 5f;
        public float leftOverInertia = 2f;
        [Tooltip("Degrees in sec")]
        public float rotationSpeed = 180;

        [Header("Collision")]
        public float colliderRadius = 0.1f;
        public float ColliderRadius => colliderRadius;

    }

}