using System;
using System.Collections.Generic;

namespace Asteroids.Framework.Reactive.Subscriptions {
    // todo-naming:
    // - Bundle
    // - Tracker
    public class SubscriptionsBundle : ISubscription {

        private readonly List<ISubscription> subscriptions = new();

        /// Add new subscription
        public void Add<T>(IReactiveProperty<T> reactiveProperty, Action<T> callback) {
            Add(new Subscription<T>(reactiveProperty, callback));
        }

        /// Add new subscription
        public void Add(ISubscription subscription) {
            subscriptions.Add(subscription);
        }

        public void ForceUpdate() {
            subscriptions.ForEach(e => e.ForceUpdate());
        }

        public void Enable() {
            subscriptions.ForEach(e => e.Enable());
        }

        public void Disable() {
            subscriptions.ForEach(e => e.Disable());
        }

        public void Dispose() {
            subscriptions.ForEach(x => x.Dispose());
            subscriptions.Clear();
        }
    }
}