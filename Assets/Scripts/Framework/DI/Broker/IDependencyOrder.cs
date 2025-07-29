using System.Collections.Generic;
using Asteroids.Framework.DI.Container;

namespace Asteroids.Framework.DI.Broker {
    // note: Naming
    // - Order
    // - Contract
    /// Dependency's resolve order (in specified sequence)
    public interface IDependencyOrder<T> {

        /// <returns>Resolved dependencies in a specified order</returns>
        public List<T> ResolveFrom(IDependencyContainer container);

    }
}