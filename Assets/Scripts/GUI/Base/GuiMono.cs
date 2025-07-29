using Asteroids.Framework.DI.Container;
using Asteroids.Framework.State;
using UnityEngine;

namespace Asteroids.GUI.Base {
    // todo-later: maybe find solution for injection to mono behavior
    // Variants:
    // - attribute - more complex (not need for simple project)
    // - interface + Object.FindOfType - through the interface, it sounds more interesting, but not supported dynamically created objects
    // - interface + visitor pattern (run on start: "diResolver.resolve(this: IInjectable)")
    public class GuiMono : MonoBehaviour {
        private static IDependencyContainer DependencyContainer { get; set; }

        protected T GetState<T>() where T : IState {
            return DependencyContainer.Resolve<T>();
        }

        public static void Inject(IDependencyContainer container) {
            DependencyContainer = container;
        }

        public static void ResetInjection() {
            DependencyContainer = null;
        }

    }
}