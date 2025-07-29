using Asteroids.Application.Bootstrapper.Config;
using Asteroids.Core.World.Common.Context;
using Asteroids.Core.World.Scene;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Application.Bootstrapper.Context {
    public class ProjectContext : IDependencyContext {
        private readonly ProjectConfig projectConfig;
        private readonly SceneContext sceneContext;

        public ProjectContext(ProjectConfig projectConfig, SceneContext sceneContext) {
            this.projectConfig = projectConfig;
            this.sceneContext = sceneContext;
        }

        public void InstallTo(IDependencyContainer container) {
            // 1. Scene context
            sceneContext.InstallTo(container);
            // 2. World Context
            new WorldContext(projectConfig.WorldConfigs).InstallTo(container);
        }
    }
}