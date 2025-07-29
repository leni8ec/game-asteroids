using System;
using System.Collections.Generic;
using Asteroids.Framework.DI.Container;

namespace Asteroids.Framework.DI.Broker {

    // note: naming
    // - Contractor
    // - Order
    // - Manager (accept orders)
    // - Broker
    // - Agent
    // - Proxy
    // - Explorer
    // - Dispatcher
    // - Provider
    // - Supplier
    // - Processor
    // - Fund
    // - Stock
    // - Hub
    /// Executes dependency's resolve orders
    public class DependencyBroker {
        private readonly IDependencyContainer container;

        public DependencyBroker(IDependencyContainer container) {
            this.container = container;
        }

        public void ResolveList<T>(List<Type> types, out List<T> resolvedList) {
            resolvedList = new List<T>(types.Count);
            for (int i = 0; i < types.Count; i++) {
                resolvedList[i] = (T) container.Resolve(types[i]);
            }
        }

        /// Execute order
        public List<T> Execute<T>(IDependencyOrder<T> order) {
            return order.ResolveFrom(container);
        }

    }
}