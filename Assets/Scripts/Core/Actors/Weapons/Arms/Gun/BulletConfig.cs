using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.Core.Actors.Weapons.Arms.Gun {
    // todo-later: split config to Arms and Ammo
    [CreateAssetMenu(menuName = "Configs/Bullet Config")]
    public class BulletConfig : EntityConfig, IColliderRadiusContainer {
        [field: Space]
        [field: Tooltip("shots per sec")]
        [field: FormerlySerializedAs("fireRate")]
        [field: SerializeField] public float FireRate { get; private set; } = 5;
        [field: Space]
        [field: FormerlySerializedAs("speed")]
        [field: SerializeField] public float Speed { get; private set; } = 5;
        [field: Tooltip("in sec")]
        [field: FormerlySerializedAs("lifetime")]
        [field: SerializeField] public float Lifetime { get; private set; } = 2;

        [field: Header("Collision")]
        [field: FormerlySerializedAs("colliderRadius")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;

    }

}