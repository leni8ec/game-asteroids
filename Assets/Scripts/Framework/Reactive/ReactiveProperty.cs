using System;
using UnityEngine;

// ReSharper disable ParameterHidesMember
namespace Asteroids.Framework.Reactive {
    [Serializable]
    public class ReactiveProperty<T> : ReactivePropertyBase<T> {

        public override event Action<T> Changed;

        [field: SerializeField]
        private T value;
        public override T Value { get => value; set => Set(value); }

        /// <summary>
        /// Reactive Property
        /// </summary>
        /// <param name="value"> initial value (*optional) </param>
        public ReactiveProperty(T value = default) {
            this.value = value;
        }

        public override bool Set(T value) {
            // todo-later: use predicate to be able to override comparers
            // (ex: throttling changes of the float or Vector3, see 'ReactiveFloat.Set()')
            if (Equals(this.value, value)) return false;
            this.value = value;
            Changed?.Invoke(this.value);
            return true;
        }

        public override void Reset() {
            Set(default);
        }

        public override void SetQuietly(T value) {
            this.value = value;
        }

        public override void ResetQuietly() {
            value = default;
        }

        public override void Dispose() {
            ResetQuietly();
            Changed = null;
        }

    }
}