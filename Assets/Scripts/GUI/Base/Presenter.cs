using System;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.Reactive.Subscriptions;
using Asteroids.Framework.State;

namespace Asteroids.GUI.Base {
    public abstract class Presenter<TView> : IPresenter
        where TView : class, IView {

        protected TView View { get; private set; }
        private Func<Type, object> GetStateFunc { get; set; }

        private SubscriptionBundle subscriptionBundle;


        public abstract void Construct();

        protected abstract void OnEnableView();

        protected abstract void OnDisableView();


        public void Setup(IView view, Func<Type, object> getState) {
            View = view as TView;
            GetStateFunc = getState;
        }

        public void Enable() {
            subscriptionBundle?.Enable();
            subscriptionBundle?.ForceUpdate();
            OnEnableView();
        }

        public void Disable() {
            subscriptionBundle?.Disable();
            OnDisableView();
        }


        protected T GetState<T>() where T : class, IState {
            return GetStateFunc(typeof(T)) as T;
        }

        /// <summary>
        /// Add a new subscription that will be:
        /// <br/> - enabled when view is enabled
        /// <br/> - disabled when view is disabled
        /// <br/> - force updated when view is enabled
        /// </summary>
        protected void Subscribe<T>(IReactiveProperty<T> reactiveProperty, Action<T> listener) {
            subscriptionBundle ??= new SubscriptionBundle();
            subscriptionBundle.Add(reactiveProperty, listener);
        }

        public void Dispose() {
            subscriptionBundle?.Dispose();
        }
    }


    public abstract class UpdateablePresenter<TView> : Presenter<TView>, IUpdateablePresenter
        where TView : UpdateableView {

        protected abstract void OnUpdateView();

        public void Update() {
            OnUpdateView();
        }

    }

}