using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies {
    public abstract class Enemy<TState, TConfig> : ColliderEntity<TState, TConfig>, IEnemy
        where TState : EntityState, IDirectionContainer
        where TConfig : EntityConfig, IColliderRadiusContainer {

        public void Init(Vector3 position, Vector3 direction) {
            State.Transform.position = position;
            State.direction = direction;
        }

    }
}