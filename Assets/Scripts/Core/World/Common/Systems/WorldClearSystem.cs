using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Ufo;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Entities.State.Objects;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Common.Systems {
    // todo-naming: There may be confusion in naming
    // What is meant by the word 'World' (which objects are included in it)?
    // - this is the game level (including camera, input, etc.) ?
    // - this is the only entities of the game level? But then how to name everything together? (with camera, input, etc.)

    // todo-naming:
    //   - 'WorldClearSystem'
    //   - 'LevelClearSystem'
    //   - "clean, clear, destroy, purge"

    /// Clear world on level end
    [UsedImplicitly]
    public class WorldClearSystem : SystemBase, IWorldClearSystem {
        private ActiveEntities ActiveEntities { get; }

        public WorldClearSystem(EntitiesState entitiesState, GameState gameState) {
            ActiveEntities = entitiesState.Active;

            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        protected override void OnDisableSystem() {
            // Player
            // note: Player - is controlled in 'PlayersSystem'

            // Destroy Ammo
            ActiveEntities.Get<Bullet>().ForEachDynamic(Despawn);
            ActiveEntities.Get<Laser>().ForEachDynamic(Despawn);
            // Destroy Ufo
            ActiveEntities.Get<Ufo>().ForEachDynamic(Despawn);
            ActiveEntities.Get<Asteroid>().ForEachDynamic(Despawn);

            // todo: implement foreach (without player filter)
            // ActiveEntities.ForEach(Despawn);
            return;
            void Despawn(IEntity entity) => entity.Despawn();
        }
    }
}