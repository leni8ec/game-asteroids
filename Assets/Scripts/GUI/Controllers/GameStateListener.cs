using Asteroids.Core.World.Common.Values;
using Asteroids.Core.World.Game;
using Asteroids.GUI.Base;
using Asteroids.GUI.Screens;
using UnityEngine;

namespace Asteroids.GUI.Controllers {
    // todo-refactor: this temporary hack needs to be replaced with a complete solution (state machine?)
    public class GameStateListener : GuiMono {
        public GameObject bgAudio;
        public GameScreen gameScreen;
        public GameOverScreen gameOverScreen;

        private void Start() {
            GameState gameState = GetState<GameState>();

            gameState.Status.Changed += OnGameStatusChanged;
            OnGameStatusChanged(GameStatus.Play); // hack
        }

        private void OnGameStatusChanged(GameStatus gameStatus) {
            if (gameStatus == GameStatus.Play) {
                gameScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                bgAudio.SetActive(true);
            } else {
                gameScreen.SetActive(false);
                gameOverScreen.SetActive(true);
                bgAudio.SetActive(false);
            }
        }
    }
}