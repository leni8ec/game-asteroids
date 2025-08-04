using System;
using Asteroids.Framework.Behavior;

namespace Asteroids.Framework.Reactive {
    /// <summary>
    /// ReadOnly 'ReactiveProperty' interface
    /// </summary>
    /// <typeparam name="T">Type of the property</typeparam>
    public interface IReactiveProperty<out T> {

        /// The 'Value' has been changed
        event Action<T> Changed;

        /// setter - are equals to method: "Property.Set(newValue)"
        T Value { get; }

    }

    // public interface IObservableValue<out T> : IValue<T> {
    //     event Action<T> Changed;
    // }
    //
    // public interface IValue<out T> : IValue {
    //     T Value { get; }
    // }
    //
    // public interface IValue {
    //     Type Type { get; }
    // }

}