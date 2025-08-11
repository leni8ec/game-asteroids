using Asteroids.Core.Actors.Common.Containers;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.State;
using UnityEngine;

namespace Asteroids.Core.Actors.Common {

    public interface IEntityState : IState, IDirectionContainer {
        /// <summary>
        /// Entity active state
        /// </summary>
        IReactiveFlag Active { get; }
    }


    public abstract class EntityState : MonoBehaviour, IEntityState {

        public ReactiveFlag active = new();
        public IReactiveFlag Active => active;

        public Vector3 direction;
        public Vector3 Direction => direction;

        // todo-consider: If this is necessary here?
        public Transform Transform { get; internal set; }

        public void Reset() {
            // active.Reset(); <- Don't reset 'Active' value!
            direction = default;

            Transform.position = default;
            Transform.rotation = default;
            Transform.localScale = Vector3.one;

            OnReset();
        }

        protected abstract void OnReset();
    }

}