using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {
    [CreateAssetMenu(menuName = "Configs/Player Config")]
    public class PlayerConfig : EntityConfig, IColliderRadiusContainer {

        [field: Space]
        [field: SerializeField] public float Speed { get; private set; } = 3f;

        [field: Tooltip("Degrees in sec")]
        [field: SerializeField] public float RotationSpeed { get; private set; } = 180;

        [field: Header("Inertia")]
        [field: Tooltip("in sec to full speed")]
        [field: SerializeField] public float AccelerationInertia { get; private set; } = 0.5f;
        [field: SerializeField] public float BrakingInertia { get; private set; } = 5f;
        [field: SerializeField] public float LeftOverInertia { get; private set; } = 2f;

        [field: Header("Collision")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;

    }
}