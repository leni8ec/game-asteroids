using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Core.World.Common.Context {
    public class WorldContext : IDependencyContext {
        private WorldConfigsContext WorldConfigsContext { get; }

        public WorldContext(WorldConfigsContext worldConfigsContext) {
            WorldConfigsContext = worldConfigsContext;
        }

        public void InstallTo(IDependencyContainer container) {
            WorldConfigsContext.InstallTo(container);
            new WorldEntitiesContext().InstallTo(container);
            new WorldSystemsContext().InstallTo(container);
            new WorldStateContext().InstallTo(container);
        }

    }
}