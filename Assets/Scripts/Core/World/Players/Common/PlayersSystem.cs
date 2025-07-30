using Asteroids.Core.Actors.Player.Services;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Players.Common {
    [UsedImplicitly]
    public class PlayersSystem : System<PlayersState>, IPlayersSystem {

        private PlayerSpawner Spawner { get; }

        public PlayersSystem(PlayersState state, PlayerSpawner spawner, GameState gameState) : base(state) {
            Spawner = spawner;

            // Game state events
            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        protected override void OnEnableSystem() {
            // Create player
            State.Active = Spawner.Spawn();
        }

        protected override void OnDisableSystem() {
            // Destroy player
            State.Active.Despawn();
            State.Active = null;
        }

    }
}