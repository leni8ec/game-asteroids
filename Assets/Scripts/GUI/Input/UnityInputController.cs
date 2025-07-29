using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Weapon;
using Asteroids.GUI.Base;
using UnityEngine.InputSystem;

namespace Asteroids.GUI.Input {
    public class UnityInputController : GuiMono {

        // Player Actions
        public InputAction moveAction;
        public InputAction rotateAction;
        public InputAction fire1Action;
        public InputAction fire2Action;

        // Game Actions
        public InputAction continueAction;

        private InputHandler handler;


        private void Start() {
            UpdateHandler();

            moveAction.performed += context => OnMoveAction(true, context);
            rotateAction.performed += context => OnRotateAction(true, context);
            fire1Action.performed += context => OnFireAction(true, 1 << 0, context);
            fire2Action.performed += context => OnFireAction(true, 2 << 0, context);

            moveAction.canceled += context => OnMoveAction(false, context);
            rotateAction.canceled += context => OnRotateAction(false, context);
            fire1Action.canceled += context => OnFireAction(false, 1 << 0, context);
            fire2Action.canceled += context => OnFireAction(false, 2 << 0, context);

            continueAction.performed += OnContinueAction;
        }

        private void UpdateHandler() {
            WeaponState weaponState = GetState<WeaponState>();
            EntitiesState entitiesState = GetState<EntitiesState>();
            GameState gameState = GetState<GameState>();
            handler = new InputHandler(weaponState, entitiesState, gameState);
        }


        private void OnEnable() {
            GetState<GameState>().LevelActiveFlag.Enabled += UpdateHandler;

            moveAction.Enable();
            rotateAction.Enable();
            fire1Action.Enable();
            fire2Action.Enable();
            continueAction.Enable();
        }

        private void OnDisable() {
            GetState<GameState>().LevelActiveFlag.Enabled -= UpdateHandler;

            moveAction.Enable();
            moveAction.Disable();
            rotateAction.Disable();
            fire1Action.Disable();
            fire2Action.Disable();
            continueAction.Disable();
        }


        private void OnFireAction(bool actionFlag, int weaponNumber, InputAction.CallbackContext context) {
            handler.FireCommand.Execute(actionFlag, weaponNumber);
        }

        private void OnMoveAction(bool actionFlag, InputAction.CallbackContext context) {
            handler.MoveCommand.Execute(actionFlag);
        }

        private void OnRotateAction(bool actionFlag, InputAction.CallbackContext context) {
            handler.RotateCommand.Execute(actionFlag, -context.ReadValue<float>()); // send inversion value of rotation
        }

        private void OnContinueAction(InputAction.CallbackContext context) {
            handler.StartGameCommand.Execute();
        }

    }
}