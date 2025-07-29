using Asteroids.Core.Actors.Player;
using Asteroids.Framework.Command;

namespace Asteroids.GUI.Input.Commands {
    public class MoveCommand : CommandBase<PlayerState> {
        public MoveCommand(PlayerState state) : base(state) { }

        public void Execute(bool activeFlag) {
            State.Move.Value = activeFlag;
        }

    }
}