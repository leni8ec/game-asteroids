using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Weapon;
using Asteroids.GUI.Input.Commands;

namespace Asteroids.GUI.Input {

    public class InputHandler {

        public FireCommand FireCommand { get; }
        public MoveCommand MoveCommand { get; }
        public RotateCommand RotateCommand { get; }
        public StartGameCommand StartGameCommand { get; }

        public InputHandler(WeaponState weaponState, EntitiesState entitiesState, GameState gameState) {

            FireCommand = new FireCommand(weaponState);
            MoveCommand = new MoveCommand(entitiesState.Player.State);
            RotateCommand = new RotateCommand(entitiesState.Player.State);
            StartGameCommand = new StartGameCommand(gameState);
        }

    }
}