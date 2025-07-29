using System;

namespace Asteroids.Framework.Reactive {
#pragma warning disable CS0660, CS0661
    public abstract class ReactivePropertyBase<T> : IReactiveProperty<T> {

        public abstract event Action<T> Changed;

        public abstract T Value { get; set; }

        /// Are equals to property setter: "Property.Value = newValue"
        /// <returns>
        /// <b>true</b> - if property has been changed to new value <br/>
        /// <b>false</b> - if the new value is identical to the current value
        /// </returns>
        public abstract bool Set(T value);

        /// Set value without reactive callback raised
        public abstract void SetQuietly(T value);

        /// Reset value without reactive callback raised
        public abstract void ResetValueQuietly();

        /// Reset property and remove all observers
        public abstract void Reset();


    #region Override assignment operators

        /// value = Property.value
        public static implicit operator T(ReactivePropertyBase<T> property) => property.Value;

        // Don't use this!
        // Property.value = value <- it will create a new instance copy instead of using existing
        // public static explicit operator ReactivePropertyBase<T>(T value) => new ReactiveProperty<T>(value);

    #endregion


    #region Override compare operators

        public static bool operator ==(ReactivePropertyBase<T> lhs, ReactivePropertyBase<T> rhs) {
            return lhs is not null && rhs is not null && lhs.Value.Equals(rhs.Value);
        }

        public static bool operator !=(ReactivePropertyBase<T> lhs, ReactivePropertyBase<T> rhs) {
            return !(lhs == rhs);
        }

        public static bool operator ==(ReactivePropertyBase<T> lhs, T rhsVal) {
            return lhs?.Value.Equals(rhsVal) == true;
        }

        public static bool operator !=(ReactivePropertyBase<T> lhs, T rhs) {
            return !(lhs == rhs);
        }

        public static bool operator ==(T lhsVal, ReactivePropertyBase<T> rhs) {
            return rhs?.Equals(lhsVal) == true;
        }

        public static bool operator !=(T lhsVal, ReactivePropertyBase<T> rhs) {
            return !(lhsVal == rhs);
        }

    #endregion


    }
}