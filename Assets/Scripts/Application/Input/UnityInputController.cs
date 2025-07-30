using Asteroids.Application.Input.InputSystem;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Players.Common;
using Asteroids.Core.World.Players.Weapons;
using Asteroids.Framework.Reactive;
using Asteroids.GUI.Base;

namespace Asteroids.Application.Input {
    public class UnityInputController : GuiMono {

        private InputActions actions;
        private InputHandler handler;

        private ReactiveFlag levelActiveFlag;

        private void Awake() {
            actions = new InputActions();
            handler = new InputHandler();

            // UI actions - not used currently
            // (but they must exist, as it's required for interaction between UnityUI and UnityInput)
            actions.UI.Disable();

            SetupCommandsToHandler();
            SetupActionsToHandler();
            levelActiveFlag = GetState<GameState>().LevelActiveFlag; // maybe not the best solution..
        }

        // (world states currently aren't changed anytime)
        private void SetupCommandsToHandler() {
            WeaponState weaponState = GetState<WeaponState>();
            PlayersState playersState = GetState<PlayersState>();
            GameState gameState = GetState<GameState>();
            CommandsRegistry commands = new(weaponState, playersState, gameState);

            handler.Setup(commands);
        }

        private void SetupActionsToHandler() {
            actions.Player.Move.performed += handler.OnMove;
            actions.Player.Rotate.performed += handler.OnRotate;
            actions.Player.Fire1.performed += handler.OnFire1;
            actions.Player.Fire2.performed += handler.OnFire2;

            actions.Menu.Play.performed += handler.OnPlay;
        }


        private void OnEnable() {
            levelActiveFlag.Changed += OnLevelActiveChanged;

            // Enable actions (for current state)
            OnLevelActiveChanged(levelActiveFlag);
        }

        private void OnDisable() {
            if (levelActiveFlag != null) {
                levelActiveFlag.Changed -= OnLevelActiveChanged;
                levelActiveFlag = null;
            }
            // Disable all actions
            actions.Disable();
        }

        private void OnLevelActiveChanged(bool active) {
            if (active) {
                actions.Player.Enable();
                actions.Menu.Disable();
            } else {
                actions.Player.Disable();
                actions.Menu.Enable();
            }
        }

    }
}