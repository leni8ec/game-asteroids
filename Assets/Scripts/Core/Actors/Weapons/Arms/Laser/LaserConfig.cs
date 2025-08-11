using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Arms.Laser {
    // todo-later: split config to Arms and Ammo
    [CreateAssetMenu(menuName = "Configs/Laser Config")]
    public class LaserConfig : EntityConfig, IColliderRadiusContainer {

        [field: Space]
        [field: Tooltip("Max shots count")]
        [field: SerializeField] public int MaxShotsCount { get; private set; } = 3;

        [field: Tooltip("Delay to restore shot")]
        [field: SerializeField] public float ShotRefillDuration { get; private set; } = 3;

        [field: Space]
        [field: Tooltip("shots per sec")]
        [field: SerializeField] public float FireRate { get; private set; } = 1f;

        [field: Space]
        [field: SerializeField] public float MaxDistance { get; private set; } = 8;

        [field: Space]
        [field: Tooltip("lifetime")]
        [field: SerializeField] public float Duration { get; private set; } = 1f;

        [field: Header("Collision")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.05f;

    }
}