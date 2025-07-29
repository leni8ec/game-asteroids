using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    [CreateAssetMenu(menuName = "Configs/Ufo Config")]
    public class UfoConfig : EntityConfig, IColliderRadiusContainer {
        [field: Space]
        [field: FormerlySerializedAs("startSpeed")]
        [field: SerializeField] public float StartSpeed { get; private set; } = 1;
        [field: FormerlySerializedAs("huntSpeed")]
        [field: SerializeField] public float HuntSpeed { get; private set; } = 1.2f;

        [field: Tooltip("in seconds")]
        [field: FormerlySerializedAs("huntDelay")]
        [field: SerializeField] public float HuntDelay { get; private set; } = 3;

        [field: Header("Collision")]
        [field: FormerlySerializedAs("colliderRadius")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;

    }
}