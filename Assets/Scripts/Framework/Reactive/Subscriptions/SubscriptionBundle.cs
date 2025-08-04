using System;
using System.Collections.Generic;

namespace Asteroids.Framework.Reactive.Subscriptions {
    // todo-naming:
    // - Bundle
    // - Tracker
    public class SubscriptionBundle : ISubscription {

        private readonly List<ISubscription> subscriptions = new();

        /// Add subscription
        public void Add<T>(IReactiveProperty<T> reactiveProperty, Action<T> callback) {
            subscriptions.Add(new Subscription<T>(reactiveProperty, callback));
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