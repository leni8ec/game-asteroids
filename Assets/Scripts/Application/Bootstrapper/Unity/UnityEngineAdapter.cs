using Asteroids.Application.Bootstrapper.Config;
using Asteroids.Application.Bootstrapper.Context;
using Asteroids.Application.Bootstrapper.Project;
using Asteroids.Core.World.Scene;
using Asteroids.Framework.DI.Container;
using Asteroids.GUI.Base;
using UnityEngine;

namespace Asteroids.Application.Bootstrapper.Unity {

    /// <summary>
    /// Base class - don't place it to unity scene!
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public class UnityEngineAdapter : MonoBehaviour {
        [Space]
        [SerializeField] private SceneContext sceneContext;

        private Engine engine;

        // todo-later: identify a separate entry point to the project
        private void Awake() {
            // Load project config
            ProjectConfig config = Resources.Load<ProjectConfig>(ProjectConfig.RESOURCE_PATH);
            // Init project context
            ProjectContext context = new(config, sceneContext);

            // Create dependency container
            IDependencyContainer container = new DependencyContainer();
            // Install project context to container
            context.InstallTo(container);

            // Init project engine
            engine = new Engine(container);
            engine.Initialize();

            // Inject to Gui
            GuiMono.Inject(container);
        }

        private void OnDestroy() {
            GuiMono.ResetInjection();
        }

        private void FixedUpdate() {
            engine.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update() {
            engine.Update(Time.deltaTime);
        }

    }
}