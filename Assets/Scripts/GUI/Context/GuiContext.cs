using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;
using Asteroids.GUI.Base;
using UnityEngine;

namespace Asteroids.GUI.Context {
    public class GuiContext : MonoBehaviour, IDependencyContext {

        public void InstallTo(IDependencyContainer container) {
            container.Register<IPresenterFactory, PresenterFactory>();
        }

    }
}