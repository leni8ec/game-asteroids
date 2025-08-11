using Asteroids.Framework.DI.Content.Bunch;
using Asteroids.Framework.Pool;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Common.Services.Factory {

    /// Factory method to create new entities
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public abstract class EntityBunchFactory<TEntity, TView, TState, TConfig, TKey>
        : EntityFactoryBase<TEntity, TView, TState>, IBunchEntityFactory<TEntity, TKey>
        where TEntity : IEntity, new()
        where TView : IEntityView
        where TState : EntityState
        where TConfig : EntityConfig {

        private Insert<TKey, TConfig> Configs { get; }

        protected EntityBunchFactory(Insert<TKey, TConfig> configs) {
            Configs = configs;
        }

        public TEntity Create(TKey key) {
            return CreateInternal(Configs[key]);
        }

        public IPool<TEntity> GeneratePool(TKey key) {
            return new Pool<TEntity>(() => Create(key), Configs[key].PoolCapacity);
        }

    }
}