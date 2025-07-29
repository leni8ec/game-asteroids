using Asteroids.Framework.Pool;
using JetBrains.Annotations;

namespace Asteroids.Framework.Entity.Services.Factory {
    /// Factory method to create new entities
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class EntityFactory<TEntity, TView, TState, TConfig>
        : EntityFactoryBase<TEntity, TView, TState>, IEntityFactory<TEntity>
        where TEntity : IEntity, new()
        where TView : IEntityView
        where TState : EntityState
        where TConfig : EntityConfig {

        private TConfig Config { get; }

        public EntityFactory(TConfig config) {
            Config = config;
        }

        public TEntity Create() {
            return CreateInternal(Config);
        }

        public IPool<TEntity> GeneratePool() {
            return new Pool<TEntity>(Create, Config.PoolCapacity);
        }

    }
}