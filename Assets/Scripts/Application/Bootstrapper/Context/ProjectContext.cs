using Asteroids.Application.Bootstrapper.Config;
using Asteroids.Core.World.Common.Context;
using Asteroids.Core.World.Scene;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;
using Asteroids.GUI.Context;

namespace Asteroids.Application.Bootstrapper.Context {
    public class ProjectContext : IDependencyContext {
        private readonly ProjectConfig projectConfig;
        private readonly SceneContext sceneContext;
        private readonly GuiContext guiContext;

        public ProjectContext(ProjectConfig projectConfig, SceneContext sceneContext, GuiContext guiContext) {
            this.projectConfig = projectConfig;
            this.sceneContext = sceneContext;
            this.guiContext = guiContext;
        }

        public void InstallTo(IDependencyContainer container) {
            // 1. Scene context
            sceneContext.InstallTo(container);
            // 2. GUI Context
            guiContext.InstallTo(container);
            // 3. World Context
            new WorldContext(projectConfig.WorldConfigs).InstallTo(container);
        }
    }
}