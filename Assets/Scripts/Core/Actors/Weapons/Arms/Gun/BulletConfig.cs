using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Arms.Gun {
    // todo-later: split config to Arms and Ammo
    [CreateAssetMenu(menuName = "Configs/Bullet Config")]
    public class BulletConfig : EntityConfig, IColliderRadiusContainer {

        [field: Space]
        [field: Tooltip("shots per sec")]
        [field: SerializeField] public float FireRate { get; private set; } = 5;

        [field: Space]
        [field: SerializeField] public float Speed { get; private set; } = 5;

        [field: Tooltip("in sec")]
        [field: SerializeField] public float Lifetime { get; private set; } = 2;

        [field: Header("Collision")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;

    }
}