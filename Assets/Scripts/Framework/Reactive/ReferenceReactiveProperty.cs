using System;

namespace Asteroids.Framework.Reactive {
    /// This feature is not used yet.
    public class ReferenceReactiveProperty<T> : ReactivePropertyBase<T>, IReactiveProperty<T> {

        private readonly Func<T> getValue;
        private readonly Action<T> setValue;

        public override event Action<T> Changed;

        public override T Value { get => getValue(); set { } }

        public ReferenceReactiveProperty(Func<T> getValue, Action<T> setValue) {
            this.getValue = getValue;
            this.setValue = setValue;
        }

        public override bool Set(T value) {
            if (Equals(getValue(), value)) return false;
            setValue(value);
            Changed?.Invoke(value);
            return true;
        }

        public override void Reset() {
            Set(default);
        }

        public override void SetQuietly(T value) {
            if (Equals(getValue(), value)) return;
            setValue(value);
        }

        public override void ResetQuietly() {
            if (Equals(getValue(), default)) return;
            setValue(default);
        }

        public override void Dispose() {
            ResetQuietly();
            Changed = null;
        }


    }
}