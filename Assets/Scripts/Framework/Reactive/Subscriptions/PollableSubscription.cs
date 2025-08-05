using System;

namespace Asteroids.Framework.Reactive.Subscriptions {

    public interface IPollableSubscription : ISubscription {
        /// Polling the observed value for changes.
        /// <br/> If value has changes, the reactive property change will be invoked.
        void PollValue();
    }

    /// <summary>
    /// Subscription that checks value changes in update
    /// </summary>
    /// <remarks><inheritdoc cref="Subscription{T}"/></remarks>
    public class PollableSubscription<T> : IPollableSubscription {

        private readonly Subscription<T> subscription;

        private readonly ReactiveProperty<T> reactiveProperty;
        private Func<T> poll;

        public PollableSubscription(Func<T> poll, Action<T> listener) {
            this.poll = poll;
            reactiveProperty = new ReactiveProperty<T>();
            subscription = new Subscription<T>(reactiveProperty, listener);

        }

        public void Dispose() {
            subscription.Dispose();
            reactiveProperty.Dispose();
            poll = null;
        }

        public void Enable() {
            subscription.Enable();
        }

        public void Disable() {
            subscription.Disable();
        }

        public void PollValue() {
            reactiveProperty.Value = poll();
        }

        public void ForceUpdate() {
            PollValue();
            subscription.ForceUpdate();
        }
    }
}