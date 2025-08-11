using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Players.Common;
using Asteroids.Framework.Command;

namespace Asteroids.Core.World.Players.Commands {
    public class RotateCommand : CommandBase<PlayersState> {

        private Player Player => State.Active;

        public RotateCommand(PlayersState state) : base(state) { }

        /// <param name="activeFlag"></param>
        /// <param name="rotateValue"> Left: -1, Right: 1 </param>
        public void Execute(float rotateValue) {
            Player.Rotate = rotateValue;
        }

    }
}