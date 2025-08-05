using System;
using System.Collections.Generic;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.Reactive.Subscriptions;
using Asteroids.Framework.State;

namespace Asteroids.GUI.Base {
    public abstract class Presenter<TView> : IPresenter
        where TView : class, IView {

        protected TView View { get; private set; }
        private Func<Type, object> GetStateFunc { get; set; }

        private SubscriptionsBundle subscriptionsBundle = new();


        public abstract void Construct();

        protected abstract void OnEnableView();

        protected abstract void OnDisableView();


        public void Setup(IView view, Func<Type, object> getState) {
            View = view as TView;
            GetStateFunc = getState;
        }

        public void Enable() {
            subscriptionsBundle.Enable();
            subscriptionsBundle.ForceUpdate();
            OnEnableView();
        }

        public void Disable() {
            subscriptionsBundle.Disable();
            OnDisableView();
        }


        protected T GetState<T>() where T : class, IState {
            return GetStateFunc(typeof(T)) as T;
        }

        /// <summary>
        /// Add a new subscription
        /// </summary>
        /// <remarks>
        /// Subscription will be:
        /// <br/> - enabled when view is enabled
        /// <br/> - disabled when view is disabled
        /// <br/> - force updated when view is enabled</remarks>
        protected void Subscribe<T>(IReactiveProperty<T> reactiveProperty, Action<T> listener) {
            subscriptionsBundle.Add(reactiveProperty, listener);
        }

        protected void AddSubscription(ISubscription subscription) {
            subscriptionsBundle.Add(subscription);
        }

        public virtual void Dispose() {
            subscriptionsBundle.Dispose();
            subscriptionsBundle = null;
        }
    }


    public abstract class UpdateablePresenter<TView> : Presenter<TView>, IUpdateablePresenter
        where TView : UpdateableView {

        private List<IPollableSubscription> pollableSubscriptions = new();

        protected abstract void OnUpdateView();

        public void Update() {
            foreach (IPollableSubscription subscription in pollableSubscriptions)
                subscription.PollValue();

            OnUpdateView();
        }

        /// <summary> Add new pollable subscription </summary>
        /// <seealso cref="PollableSubscription{T}"/>
        /// <remarks> <inheritdoc cref="Presenter{TView}.Subscribe{T}"/> </remarks>
        protected void Subscribe<T>(Func<T> poll, Action<T> listener) {
            IPollableSubscription subscription = new PollableSubscription<T>(poll, listener);
            pollableSubscriptions.Add(subscription);
            AddSubscription(subscription);
        }

        public override void Dispose() {
            base.Dispose();
            pollableSubscriptions.Clear();
            pollableSubscriptions = null;
        }

    }

}