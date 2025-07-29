using Asteroids.Core.World.Game;
using Asteroids.Framework.Command;

namespace Asteroids.GUI.Input.Commands {
    public class StartGameCommand : CommandBase<GameState> {
        public StartGameCommand(GameState state) : base(state) { }

        public void Execute() {
            State.LevelActiveFlag.Enable();
        }

    }
}