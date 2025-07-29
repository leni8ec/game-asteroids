using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Framework.Entity {
    public abstract class EntityConfig : ScriptableObject, IConfig {
        [field: Space]
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: Tooltip("Initial capacity of the object pool\n\nLeave '0' when pool isn't used")]
        [field: SerializeField] public int PoolCapacity { get; private set; }
    }

    public abstract class EntityConfig<TKey> : EntityConfig {
        public abstract TKey GetConfigKey();
    }

}