using System.Collections.Generic;
using Asteroids.Core.Actors.Common.Services.Factory;
using Asteroids.Framework.Pool;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Common.Services.Spawner {
    /// <summary>
    /// Pullable bunch entity spawner
    /// <br/>
    /// <br/> On kill entity - return it to Pool
    /// <br/> Has own pool for each entity config
    /// </summary>
    /// <typeparam name="TEntity"> Target Entity </typeparam>
    /// <typeparam name="TFactory"> Entity factory</typeparam>
    /// <typeparam name="TConfig"> Entity config</typeparam>
    /// <typeparam name="TKey"> Key to resolve concrete configs (from container/repository) </typeparam>
    [UsedImplicitly]
    public abstract class PoolableBunchEntitySpawner<TEntity, TFactory, TKey> : EntitySpawnerBase<TEntity, TFactory>
        where TEntity : IEntity
        where TFactory : IBunchEntityFactory<TEntity, TKey> {

        private TFactory Factory { get; }
        private readonly Dictionary<TKey, IPool<TEntity>> pools = new();

        protected PoolableBunchEntitySpawner(TFactory factory) {
            factory.UseContainer("Pool");
            Factory = factory;
        }

        protected TEntity SpawnInternal(TKey key) {
            TEntity entity = ObtainEntity(key);
            SubscribeToEntityDespawn(entity, key);
            OnSpawnInternal(entity);
            return entity;
        }

        /// Get existing object from the pool or create by factory method
        private TEntity ObtainEntity(TKey key) {
            if (pools.TryGetValue(key, out var pool))
                return pool.Take();

            return AddPool(key).Take();
        }

        private IPool<TEntity> AddPool(TKey key) {
            IPool<TEntity> pool = Factory.GeneratePool(key);
            activeEntities.Capacity += pool.InitialCapacity;
            pools[key] = pool;
            return pool;
        }

        private void SubscribeToEntityDespawn(TEntity entity, TKey key) {
            entity.DespawnEvent += OnEntityDespawn;
            return;

            void OnEntityDespawn() {
                entity.DespawnEvent -= OnEntityDespawn;
                OnDespawnInternal(entity);
                pools[key].Return(entity);
            }
        }

    }
}