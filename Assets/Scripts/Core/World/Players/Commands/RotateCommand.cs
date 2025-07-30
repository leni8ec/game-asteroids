using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Players.Common;
using Asteroids.Framework.Command;

namespace Asteroids.Core.World.Players.Commands {
    public class RotateCommand : CommandBase<PlayersState> {

        private PlayerState PlayerState => State.Active.State;

        public RotateCommand(PlayersState state) : base(state) { }

        /// <param name="activeFlag"></param>
        /// <param name="rotateValue"> Left: -1, Right: 1 </param>
        public void Execute(bool activeFlag, float rotateValue) {
            if (activeFlag) {
                PlayerState.Rotate.Value = rotateValue < 0 ? -1 : 1;
            } else {
                PlayerState.Rotate.Value = 0;
            }
        }

    }
}