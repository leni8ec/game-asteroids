using Asteroids.Framework.Command;

namespace Asteroids.Core.World.Game.Commands {
    public class StartGameCommand : CommandBase<GameState> {

        public StartGameCommand(GameState state) : base(state) { }

        public void Execute() {
            State.LevelActiveFlag.Enable();
        }

    }
}