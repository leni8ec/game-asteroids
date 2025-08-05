using System;

namespace Asteroids.Framework.Reactive.Subscriptions {
    /// <remarks> Subscription not enabled by default </remarks>
    public class Subscription<T> : ISubscription {

        protected IReactiveProperty<T> reactiveProperty;
        private Action<T> listener;

        public Subscription(IReactiveProperty<T> reactiveProperty, Action<T> listener) {
            this.reactiveProperty = reactiveProperty;
            this.listener = listener;
        }

        public virtual void Dispose() {
            Disable();
            reactiveProperty = null;
            listener = null;
        }

        public void Enable() {
            reactiveProperty.Changed += listener;
        }

        public void Disable() {
            reactiveProperty.Changed -= listener;
        }

        public void ForceUpdate() {
            listener(reactiveProperty.Value);
        }

    }
}