using Asteroids.Core.Actors.Common.Services.Factory;
using Asteroids.Core.Actors.Common.Services.Spawner.Extra;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Common.Services.Spawner {
    /// <summary>
    /// Not poolable entity spawner
    /// <br/>
    /// <br/> New entity will be Instantiated/Destroyed each time at Spawn/Despawn
    /// </summary>
    [UsedImplicitly]
    public abstract class EntitySpawnerBase<TEntity, TFactory> : IEntitySpawner<TEntity>
        where TEntity : IEntity
        where TFactory : IEntityFactory {

        /// Active entities
        /// <br/><br/>
        /// Must be initialized, because it is a dependency for other scopes
        // todo-later: maybe remove from it ?
        // Move to own system with subscribe to spawn/despawn events ?
        protected readonly DynamicList<TEntity> activeEntities = new(0);
        public IReadOnlyDynamicList<TEntity> ActiveEntities => activeEntities;

        protected void OnSpawnInternal(TEntity entity) {
            ActivateEntity(entity);
            entity.Spawned();
        }

        protected void OnDespawnInternal(TEntity entity) {
            DeactivateEntity(entity);
            ResetEntity(entity);
        }

        private void ActivateEntity(TEntity entity) {
            entity.SetActive(true);
            activeEntities.Add(entity);
        }

        private void DeactivateEntity(TEntity entity) {
            activeEntities.Remove(entity); // Complexity: O(N)
            entity.SetActive(false);
        }

        private void ResetEntity(TEntity entity) {
            entity.Reset();
        }

    }
}