using Asteroids.Core.World.Common.Values;
using Asteroids.Core.World.Game;
using Asteroids.GUI.Base;
using Asteroids.GUI.Screens;
using UnityEngine;

namespace Asteroids.GUI.Controllers {
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
                gameScreen.gameObject.SetActive(true);
                gameOverScreen.gameObject.SetActive(false);
                bgAudio.SetActive(true);
            } else {
                gameScreen.gameObject.SetActive(false);
                gameOverScreen.gameObject.SetActive(true);
                bgAudio.SetActive(false);
            }
        }
    }
}