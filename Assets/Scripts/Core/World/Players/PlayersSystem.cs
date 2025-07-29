using Asteroids.Core.Actors.Player.Services;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Players {
    [UsedImplicitly]
    public class PlayersSystem : SystemBase, IPlayersSystem {
        private PlayerSpawner Spawner { get; }
        private EntitiesState EntitiesState { get; }

        public PlayersSystem(PlayerSpawner spawner, GameState gameState, EntitiesState entitiesState) {
            Spawner = spawner;
            EntitiesState = entitiesState;

            // Game state events
            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        protected override void OnEnableSystem() {
            // Create player
            EntitiesState.Player = Spawner.Spawn();
        }

        protected override void OnDisableSystem() {
            EntitiesState.Player.Despawn();
            EntitiesState.Player = null;
        }

    }
}