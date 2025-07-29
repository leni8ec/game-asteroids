using Asteroids.Framework.DI.Container;

namespace Asteroids.Framework.DI.Context {
    public interface IDependencyContext {

        /// <param name="container">Parent dependency container</param>
        /// <param name="lifeCycle">Parent context lifecycle (use provided value or ignore it)</param>
        void InstallTo(IDependencyContainer container);

    }
}