using Asteroids.Framework.Pool;

namespace Asteroids.Framework.Entity.Services.Factory {

    /// Entity factory
    public interface IEntityFactory {

        /// <inheritdoc cref="EntityContainer(string)"/>
        void UseContainer(string containerName = null);

    }

    /// Entity factory
    public interface IEntityFactory<TEntity> : IEntityFactory
        where TEntity : IEntity {

        /// Create entity, add components and initialize all it
        TEntity Create();

        /// Create a new pool
        /// <remarks>Use visitor pattern to encapsulate entity configs in factory</remarks>
        IPool<TEntity> GeneratePool();
    }

    /// Keyed entity factory
    public interface IBunchEntityFactory<TEntity, in TKey> : IEntityFactory
        where TEntity : IEntity {

        /// <inheritdoc cref="IEntityFactory{TEntity}.Create"/>
        TEntity Create(TKey key);

        /// <inheritdoc cref="IEntityFactory{TEntity}.GeneratePool"/>
        IPool<TEntity> GeneratePool(TKey key);

    }

}