using Asteroids.Core.Actors.Player;
using Asteroids.Framework.Command;

namespace Asteroids.GUI.Input.Commands {
    public class RotateCommand : CommandBase<PlayerState> {
        public RotateCommand(PlayerState state) : base(state) { }

        /// <param name="activeFlag"></param>
        /// <param name="rotateValue"> Left: -1, Right: 1 </param>
        public void Execute(bool activeFlag, float rotateValue) {
            if (activeFlag) {
                State.Rotate.Value = rotateValue < 0 ? -1 : 1;
            } else {
                State.Rotate.Value = 0;
            }
        }

    }
}