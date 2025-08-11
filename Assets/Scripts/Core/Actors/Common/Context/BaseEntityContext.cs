using Asteroids.Core.Actors.Common.Services.Factory;
using Asteroids.Core.Actors.Common.Services.Spawner;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Core.Actors.Common.Context {
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