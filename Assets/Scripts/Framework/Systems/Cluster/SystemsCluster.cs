using System;
using System.Collections.Generic;
using Asteroids.Framework.Systems.Behaviour;

namespace Asteroids.Framework.Systems.Cluster {
    /// Ordered systems list
    public class SystemsCluster : ISystemsCluster {
        private readonly Dictionary<Type, ISystem> systems = new();
        private readonly List<IFixedUpdateSystem> fixedUpdateSystems = new();
        private readonly List<IUpdateSystem> updateSystems = new();

        public SystemsCluster(List<ISystem> systems) {
            Add(systems);
        }

        // Initialize system by their order
        public void Initialize() {
            foreach (ISystem system in systems.Values)
                system.Initialize();
        }


        public void Add<T>(List<T> systemsList) where T : ISystem {
            foreach (T system in systemsList)
                Add(system);
        }

        public void Add<T>(T system) where T : ISystem {
            // Fill systems
            systems.Add(system.GetType(), system);
            // Fill update
            if (system is IFixedUpdateSystem fixedUpdateSystem) fixedUpdateSystems.Add(fixedUpdateSystem);
            if (system is IUpdateSystem updateSystem) updateSystems.Add(updateSystem);
        }

        public void FixedUpdate(float fixedDeltaTime) {
            foreach (IFixedUpdateSystem system in fixedUpdateSystems) {
                if (system.SystemEnabled) system.FixedUpdateSystem(fixedDeltaTime);
            }
        }

        public void Update(float deltaTime) {
            foreach (IUpdateSystem system in updateSystems) {
                if (system.SystemEnabled) system.UpdateSystem(deltaTime);
            }
        }

    }
}