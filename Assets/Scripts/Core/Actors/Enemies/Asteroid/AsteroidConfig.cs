using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.Core.Actors.Enemies.Asteroid {

    [CreateAssetMenu(menuName = "Configs/Asteroid Config")]
    public class AsteroidConfig : KeyedEntityConfig<AsteroidSize>, IColliderRadiusContainer {
        [field: Space]
        [field: FormerlySerializedAs("size")]
        [field: SerializeField] public AsteroidSize Size { get; private set; }
        [field: Space]
        [field: FormerlySerializedAs("speed")]
        [field: SerializeField] public float Speed { get; private set; } = 1f;
        [field: Tooltip("How many new smaller fragments on destroyed")]
        [field: FormerlySerializedAs("destroyFragments")]
        [field: SerializeField] public int DestroyFragments { get; private set; } = 4;

        [field: Header("Collision")]
        [field: FormerlySerializedAs("colliderRadius")]
        [field: SerializeField] public float ColliderRadius { get; private set; } = 0.1f;


        public override AsteroidSize GetConfigKey() {
            return Size;
        }
    }

}