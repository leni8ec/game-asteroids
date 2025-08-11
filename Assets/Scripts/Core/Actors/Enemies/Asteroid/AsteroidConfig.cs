using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Asteroid {
    [CreateAssetMenu(menuName = "Configs/Asteroid Config")]
    public class AsteroidConfig : KeyedEntityConfig<AsteroidSize>, IColliderRadiusContainer {

        [field: Space]
        [field: SerializeField] public AsteroidSize Size { get; private set; }

        [field: Space]
        [field: SerializeField] public float Speed { get; private set; } = 1f;

        [field: Tooltip("How many new smaller fragments on destroyed")]
        [field: SerializeField] public int DestroyFragments { get; private set; } = 4;

        [field: Header("Collision")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;


        public override AsteroidSize GetConfigKey() => Size;

    }
}