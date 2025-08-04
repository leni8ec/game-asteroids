using System;

namespace Asteroids.Framework.Reactive.Subscriptions {
    public interface ISubscription : IDisposable {

        /// Add listener to observable
        void Enable();

        /// Remove listener from observable
        void Disable();

        // todo-naming: find a better naming
        /// Force update listener with the current observed value
        /// <remarks> Typically used to get the current value when the listener is initialized </remarks>
        void ForceUpdate();

    }
}