using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo {
    public abstract class Ammo<TState, TConfig> : ColliderEntity<TState, TConfig>
        where TState : EntityState, IDirectionContainer, new()
        where TConfig : EntityConfig, IColliderRadiusContainer, new() {

        public Vector3 Direction => State.Direction;

        public virtual void Set(Vector3 startPoint, Vector3 direction) {
            Transform.position = startPoint;
            State.Direction = direction;
        }

    }
}