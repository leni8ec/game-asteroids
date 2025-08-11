using Asteroids.Core.Actors.Common.Services.Factory;
using Asteroids.Framework.Pool;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Common.Services.Spawner {
    /// Pullable entity spawner
    /// <br/>
    /// <br/> On kill entity - return it to Pool
    [UsedImplicitly]
    public abstract class PoolableEntitySpawner<TEntity, TFactory> : EntitySpawnerBase<TEntity, TFactory>
        where TEntity : IEntity
        where TFactory : IEntityFactory<TEntity> {

        private readonly IPool<TEntity> pool;

        protected PoolableEntitySpawner(TFactory factory) {
            factory.UseContainer("Pool");
            pool = factory.GeneratePool();
            activeEntities.Capacity = pool.InitialCapacity;
        }

        protected TEntity SpawnInternal() {
            TEntity entity = pool.Take();
            SubscribeToEntityDespawn(entity);
            OnSpawnInternal(entity);
            return entity;
        }

        private void SubscribeToEntityDespawn(TEntity entity) {
            entity.DespawnEvent += OnEntityDespawn;
            return;

            void OnEntityDespawn() {
                entity.DespawnEvent -= OnEntityDespawn;
                OnDespawnInternal(entity);
                pool.Return(entity);
            }
        }

    }
}