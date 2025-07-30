using Asteroids.Core.World.Game.Commands;
using Asteroids.Core.World.Players.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.GUI.Input {

    public class InputHandler {

        private CommandsRegistry Commands { get; set; }

        public void Setup(CommandsRegistry commands) {
            Commands = commands;
        }

        public void OnMoveAction(InputAction.CallbackContext input) {
            bool actionFlag = input.phase == InputActionPhase.Performed;
            Commands.Get<MoveCommand>().Execute(actionFlag);
        }

        public void OnRotateAction(InputAction.CallbackContext input) {
            bool actionFlag = input.phase == InputActionPhase.Performed;
            Commands.Get<RotateCommand>().Execute(actionFlag, -input.ReadValue<float>()); // send inversion value of rotation
        }

        public void OnFire1Action(InputAction.CallbackContext input) {
            bool actionFlag = input.phase == InputActionPhase.Performed;
            const int weaponNumber = 1;
            Commands.Get<FireCommand>().Execute(actionFlag, weaponNumber);
        }

        public void OnFire2Action(InputAction.CallbackContext input) {
            bool actionFlag = input.phase == InputActionPhase.Performed;
            const int weaponNumber = 2;
            Commands.Get<FireCommand>().Execute(actionFlag, weaponNumber);
        }

        public void OnContinueAction(InputAction.CallbackContext input) {
            Commands.Get<StartGameCommand>().Execute();
        }

    }
}