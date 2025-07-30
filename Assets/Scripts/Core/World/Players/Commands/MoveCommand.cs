using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Players.Common;
using Asteroids.Framework.Command;

namespace Asteroids.Core.World.Players.Commands {
    public class MoveCommand : CommandBase<PlayersState> {

        private PlayerState PlayerState => State.Active.State;

        public MoveCommand(PlayersState state) : base(state) { }

        public void Execute(bool activeFlag) {
            PlayerState.Move.Value = activeFlag;
        }

    }
}