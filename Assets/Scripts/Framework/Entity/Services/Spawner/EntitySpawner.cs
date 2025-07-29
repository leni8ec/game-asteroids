using Asteroids.Framework.Entity.Services.Factory;
using JetBrains.Annotations;

namespace Asteroids.Framework.Entity.Services.Spawner {
    /// <summary>
    /// Not poolable entity spawner
    /// <br/>
    /// <br/> New entity will be Instantiated/Destroyed each time at Spawn/Despawn
    /// </summary>
    [UsedImplicitly]
    public abstract class EntitySpawner<TEntity, TFactory> : EntitySpawnerBase<TEntity, TFactory>
        where TEntity : IEntity
        where TFactory : IEntityFactory<TEntity> {

        private TFactory Factory { get; }

        protected EntitySpawner(TFactory factory) {
            Factory = factory;
        }

        /// Get Entity from Pool or create by Factory and then - initialize it
        protected TEntity SpawnInternal() {
            TEntity entity = Factory.Create();
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
                entity.Destroy();
            }
        }

    }
}