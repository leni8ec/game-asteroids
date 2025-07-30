using System.Collections.Generic;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Players.Common;
using Asteroids.Core.World.Players.Weapons;
using Asteroids.Framework.Reactive;
using Asteroids.GUI.Base;
using UnityEngine;
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

        // Input handler
        private readonly InputHandler handler = new();

        // Actions lists
        private readonly List<InputAction> gameActions = new();
        private readonly List<InputAction> menuActions = new();

        private void Awake() {
            ListActions();
            SetupHandler();
            SetupActions();
        }

        private void ListActions() {
            gameActions.Add(moveAction);
            gameActions.Add(rotateAction);
            gameActions.Add(fire1Action);
            gameActions.Add(fire2Action);

            menuActions.Add(continueAction);
        }

        private void SetupActions() {
            moveAction.performed += handler.OnMoveAction;
            rotateAction.performed += handler.OnRotateAction;
            fire1Action.performed += handler.OnFire1Action;
            fire2Action.performed += handler.OnFire2Action;

            moveAction.canceled += handler.OnMoveAction;
            rotateAction.canceled += handler.OnRotateAction;
            fire1Action.canceled += handler.OnFire1Action;
            fire2Action.canceled += handler.OnFire2Action;

            continueAction.performed += handler.OnContinueAction;
        }

        private void SetupHandler() {
            WeaponState weaponState = GetState<WeaponState>();
            PlayersState playersState = GetState<PlayersState>();
            GameState gameState = GetState<GameState>();
            CommandsRegistry commands = new(weaponState, playersState, gameState);

            handler.Setup(commands);
        }


        private void OnEnable() {
            ReactiveFlag levelActiveFlag = GetState<GameState>().LevelActiveFlag;
            levelActiveFlag.Changed += OnLevelActiveChanged;
            OnLevelActiveChanged(levelActiveFlag);
        }

        // note: hack
        // Use 'Dispose' for disable actions, not 'Disable' or 'Reset',
        // because it will be call canceled trigger of the action
        private void OnDisable() {
            GetState<GameState>().LevelActiveFlag.Changed -= OnLevelActiveChanged;
            foreach (InputAction action in gameActions) action.Dispose();
            foreach (InputAction action in menuActions) action.Dispose();
        }

        private void OnLevelActiveChanged(bool active) {
            foreach (InputAction gameAction in gameActions) {
                if (active) gameAction.Enable();
                else gameAction.Dispose();

            }
            foreach (InputAction menuAction in menuActions) {
                if (active) menuAction.Disable();
                else menuAction.Enable();
            }
        }

    }
}