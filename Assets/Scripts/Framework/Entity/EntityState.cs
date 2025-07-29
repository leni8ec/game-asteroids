using System;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.State;
using UnityEngine;

namespace Asteroids.Framework.Entity {
    [Serializable]
    public abstract class EntityState : MonoBehaviour, IState {
        /// <summary>
        /// Entity active state
        /// </summary>
        public ReactiveFlag Active { get; private set; } = new();

        public Transform Transform { get; set; } // todo-consider: If this is necessary here?

        public void Reset() {
            Transform.position = default;
            Transform.eulerAngles = default;
            Transform.localScale = Vector3.one;

            // Active.Reset(); <- Don't reset 'Active' value!

            OnReset();
        }

        protected abstract void OnReset();

    }
}