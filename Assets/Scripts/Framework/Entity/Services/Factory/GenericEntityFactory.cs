namespace Asteroids.Framework.Entity.Services.Factory {
    public class GenericEntityFactory<T, TView, TState, TConfig> : EntityFactory<T, TView, TState, TConfig>
        where T : IEntity, new()
        where TView : IEntityView
        where TState : EntityState
        where TConfig : EntityConfig {

        protected GenericEntityFactory(TConfig config) : base(config) { }

    }
}