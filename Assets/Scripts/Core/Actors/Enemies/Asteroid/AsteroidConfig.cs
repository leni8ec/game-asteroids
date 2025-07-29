using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Asteroid {

    [CreateAssetMenu(menuName = "Configs/Asteroid Config")]
    public class AsteroidConfig : EntityConfig<AsteroidSize>, IColliderRadiusContainer {
        [Space]
        public AsteroidSize size;
        [Space]
        public float speed = 1f;
        [Tooltip("How many new smaller fragments on destroyed")]
        public int destroyFragments = 4;

        [Header("Collision")]
        public float colliderRadius = 0.1f;

        public float ColliderRadius => colliderRadius;

        public override AsteroidSize GetConfigKey() {
            return size;
        }
    }

}