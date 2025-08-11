using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Common {
    public abstract class ColliderEntity<TState, TConfig> : Entity<TState, TConfig>, ICollider
        where TState : EntityState
        where TConfig : EntityConfig, IColliderRadiusContainer {

        public float ColliderRadius => Config.ColliderRadius;
        public Vector3 Pos => Transform.position;

    }
}