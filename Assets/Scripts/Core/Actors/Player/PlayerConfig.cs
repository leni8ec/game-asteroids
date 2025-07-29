using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.Core.Actors.Player {
    [CreateAssetMenu(menuName = "Configs/Player Config")]
    public class PlayerConfig : EntityConfig, IColliderRadiusContainer {
        [field: Space]
        [field: FormerlySerializedAs("speed")]
        [field: SerializeField] public float Speed { get; private set; } = 3f;
        [field: Tooltip("in sec to full speed")]
        [field: FormerlySerializedAs("accelerationInertia")]
        [field: SerializeField] public float AccelerationInertia { get; private set; } = 0.5f;
        [field: FormerlySerializedAs("brakingInertia")]
        [field: SerializeField] public float BrakingInertia { get; private set; } = 5f;
        [field: FormerlySerializedAs("leftOverInertia")]
        [field: SerializeField] public float LeftOverInertia { get; private set; } = 2f;
        [field: Tooltip("Degrees in sec")]
        [field: FormerlySerializedAs("rotationSpeed")]
        [field: SerializeField] public float RotationSpeed { get; private set; } = 180;

        [field: Header("Collision")]
        [field: FormerlySerializedAs("colliderRadius")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;

    }

}