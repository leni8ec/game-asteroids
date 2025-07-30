using Asteroids.Framework.State;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Players.Common {
    // todo-naming: it's confused with `PlayerState` - find other state (system) name
    // - PlayersRegistryState
    // - PlayersRegistry
    [UsedImplicitly]
    public class PlayersState : IState {

        // todo-consider: need to investigate it (maybe find a more reliable solution)
        // - use 'Lazy<>' in Systems ?
        ///  Active Player
        public Actors.Player.Player Active { get; internal set; }

        public void Reset() {
            Active = null;
        }

    }
}