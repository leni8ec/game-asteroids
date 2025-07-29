using Asteroids.Framework.Entity.Services.Factory;
using JetBrains.Annotations;

namespace Asteroids.Framework.Entity.Services.Spawner {
    /// <remarks> Not used </remarks>
    [UsedImplicitly]
    public class GenericEntitySpawner<TEntity, TFactory, TConfig> : EntitySpawner<TEntity, TFactory>
        where TEntity : IEntity
        where TFactory : IEntityFactory<TEntity>
        where TConfig : EntityConfig {

        public GenericEntitySpawner(TFactory factory) : base(factory) { }

        public TEntity Spawn() {
            return SpawnInternal();
        }

    }
}