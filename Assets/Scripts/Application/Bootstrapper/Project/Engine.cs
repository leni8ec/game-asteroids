using System.Collections.Generic;
using Asteroids.Core.World.Common.Context;
using Asteroids.Framework.DI.Broker;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Cluster;

namespace Asteroids.Application.Bootstrapper.Project {
    public class Engine {
        private ISystemsCluster worldSystemsCluster;
        private readonly DependencyBroker dependencyBroker;

        public Engine(IDependencyContainer container) {
            dependencyBroker = new DependencyBroker(container);
        }

        public void Initialize() {
            // Systems order resolver
            List<ISystem> worldSystems = dependencyBroker.Execute(new WorldSystemsOrder());

            // Systems cluster
            worldSystemsCluster = new SystemsCluster(worldSystems);
            worldSystemsCluster.Initialize();
        }

        public void FixedUpdate(float fixedDeltaTime) {
            worldSystemsCluster.FixedUpdate(fixedDeltaTime);
        }

        public void Update(float deltaTime) {
            worldSystemsCluster.Update(deltaTime);
        }

    }
}