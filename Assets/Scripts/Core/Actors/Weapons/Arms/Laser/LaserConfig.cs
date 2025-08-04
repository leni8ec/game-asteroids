using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.Core.Actors.Weapons.Arms.Laser {
    // todo-later: split config to Arms and Ammo
    [CreateAssetMenu(menuName = "Configs/Laser Config")]
    public class LaserConfig : EntityConfig, IColliderRadiusContainer {
        [field: Space]
        [field: Tooltip("Max shots count")]
        [field: FormerlySerializedAs("maxShotsCount")]
        [field: SerializeField] public int MaxShotsCount { get; private set; } = 3;
        [field: Tooltip("Delay to restore shot")]
        [field: FormerlySerializedAs("shotRefillDuration")]
        [field: SerializeField] public float ShotRefillDuration { get; private set; } = 3;
        [field: Space]
        [field: Tooltip("shots per sec")]
        [field: FormerlySerializedAs("fireRate")]
        [field: SerializeField] public float FireRate { get; private set; } = 1f;
        [field: Space]
        [field: FormerlySerializedAs("maxDistance")]
        [field: SerializeField] public float MaxDistance { get; private set; } = 8;
        [field: Space]
        [field: Tooltip("lifetime")]
        [field: FormerlySerializedAs("duration")]
        [field: SerializeField] public float Duration { get; private set; } = 1f;

        [field: Header("Collision")]
        [field: FormerlySerializedAs("colliderRadius")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.05f;

    }
}