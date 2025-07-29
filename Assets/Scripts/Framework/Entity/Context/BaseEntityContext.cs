using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;
using Asteroids.Framework.Entity.Services.Factory;
using Asteroids.Framework.Entity.Services.Spawner;

namespace Asteroids.Framework.Entity.Context {
    /// Base context registrar that registers specified generic Factory and Spawner
    public abstract class BaseEntityContext<TEntity, TFactory, TSpawner> : IDependencyContext
        where TEntity : IEntity
        where TFactory : IEntityFactory
        where TSpawner : IEntitySpawner<TEntity> {

        public virtual void InstallTo(IDependencyContainer container) {
            container.Register<TFactory>();
            container.Register<TSpawner>();
        }
    }
}