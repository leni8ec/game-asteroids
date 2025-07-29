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

        // /// <summary>
        // /// Property with a specified initial value
        // /// </summary>
        // /// <param name="value">initial value</param>
        // public ReactiveProperty(T value) {
        //     this.value = value;
        // }

        public override bool Set(T value) {
            if (Equals(this.value, value)) return false;
            this.value = value;
            Changed?.Invoke(this.value);
            return true;
        }

        public override void SetQuietly(T value) {
            this.value = value;
        }

        public override void ResetValueQuietly() {
            value = default;
        }

        public override void Reset() {
            ResetValueQuietly();
            Changed = null;
        }

    }
}