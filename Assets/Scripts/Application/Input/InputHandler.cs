using Asteroids.Core.World.Game.Commands;
using Asteroids.Core.World.Players.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Application.Input {

    public class InputHandler {

        private CommandsRegistry Commands { get; set; }

        public void Setup(CommandsRegistry commands) {
            Commands = commands;
        }


    #region Menu

        public void OnPlay(InputAction.CallbackContext input) {
            bool pressed = input.control.IsPressed();
            if (!pressed) return;
            Commands.Get<StartGameCommand>().Execute();
        }

    #endregion


    #region Game

        public void OnMove(InputAction.CallbackContext input) {
            bool pressed = input.control.IsPressed();
            Commands.Get<MoveCommand>().Execute(pressed);
        }

        public void OnRotate(InputAction.CallbackContext input) {
            float rotate = -input.ReadValue<float>(); // get inverse value of rotation
            Commands.Get<RotateCommand>().Execute(rotate);
        }

        public void OnFire1(InputAction.CallbackContext input) {
            bool pressed = input.control.IsPressed();
            const int weaponNumber = 1;
            Commands.Get<FireCommand>().Execute(pressed, weaponNumber);
        }

        public void OnFire2(InputAction.CallbackContext input) {
            bool pressed = input.control.IsPressed();
            const int weaponNumber = 2;
            Commands.Get<FireCommand>().Execute(pressed, weaponNumber);
        }

    #endregion


    }
}