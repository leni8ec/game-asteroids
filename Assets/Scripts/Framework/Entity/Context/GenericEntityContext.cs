using System;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;
using Asteroids.Framework.Entity.Services.Factory;
using Asteroids.Framework.Entity.Services.Spawner;

namespace Asteroids.Framework.Entity.Context {
    /// Generic context registrar that registers specified types of the Factory and Spawner  (which can be overridden)
    public abstract class GenericEntityContext<T, TView, TState, TConfig> : IDependencyContext
        where T : IEntity, new()
        where TView : IEntityView
        where TState : EntityState
        where TConfig : EntityConfig {

        protected virtual Type Factory => typeof(GenericEntityFactory<T, TView, TState, TConfig>);
        protected virtual Type Spawner => typeof(GenericEntitySpawner<T, GenericEntityFactory<T, TView, TState, TConfig>, TConfig>);

        public virtual void InstallTo(IDependencyContainer container) {
            container.Register(Factory);
            container.Register(Spawner);
        }
    }
}