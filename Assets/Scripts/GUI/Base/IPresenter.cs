using System;

namespace Asteroids.GUI.Base {

    public interface IPresenter : IDisposable {

        public void Setup(IView view, Func<Type, object> getState);

        void Construct();

        void Enable();

        void Disable();

    }


    public interface IUpdateablePresenter : IPresenter {

        void Update();

    }

}