using System;

namespace Asteroids.GUI.Base {
    public abstract class View : GuiMono, IView {

        protected IPresenter presenter;

        protected virtual void Awake() {
            // todo-consider: maybe extract presenter initialization from View to a separate view service
            presenter = CreatePresenterMethod();
            presenter.Setup(this, GetState);
            presenter.Construct();
        }

        protected virtual void OnEnable() {
            presenter.Enable();
        }

        protected virtual void OnDisable() {
            presenter.Disable();
        }

        private void OnDestroy() {
            presenter.Dispose();
        }

        public void SetActive(bool active) {
            gameObject.SetActive(active);
        }

    }

    public abstract class UpdateableView : View {

        // Use singlecast delegate instead of use casting in each 'Update()' call due to performance reasons
        private event Action OnUpdate;

        protected override void Awake() {
            base.Awake();
            OnUpdate = ((IUpdateablePresenter) presenter).Update;
        }

        protected virtual void Update() {
            OnUpdate!.Invoke();
        }

    }
}