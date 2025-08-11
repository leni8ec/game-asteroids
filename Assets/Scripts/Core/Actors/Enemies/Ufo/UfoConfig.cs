using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    [CreateAssetMenu(menuName = "Configs/Ufo Config")]
    public class UfoConfig : EntityConfig, IColliderRadiusContainer {

        [field: Space]
        [field: SerializeField] public float StartSpeed { get; private set; } = 1;
        [field: SerializeField] public float HuntSpeed { get; private set; } = 1.2f;

        [field: Tooltip("in seconds")]
        [field: SerializeField] public float HuntDelay { get; private set; } = 3;

        [field: Header("Collision")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;

    }
}