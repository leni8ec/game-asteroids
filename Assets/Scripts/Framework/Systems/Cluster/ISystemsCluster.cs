using System.Collections.Generic;

namespace Asteroids.Framework.Systems.Cluster {
    public interface ISystemsCluster {

        public void Add<T>(List<T> systemsList) where T : ISystem;

        public void Add<T>(T system) where T : ISystem;

        /// <summary>
        /// Called after all systems constructors is called
        /// </summary>
        public void Initialize();

        void FixedUpdate(float fixedDeltaTime);

        void Update(float deltaTime);

    }
}