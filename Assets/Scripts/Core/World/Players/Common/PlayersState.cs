using Asteroids.Core.Actors.Player;
using Asteroids.Framework.State;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Players.Common {
    // todo-naming: it's confused with `PlayerState` - find other state (system) name
    // - PlayersRegistryState
    // - PlayersRegistry
    [UsedImplicitly]
    public class PlayersState : IState {

        ///  Active Player
        public Player Active { get; internal set; }

        public void Reset() {
            Active = null;
        }

    }
}