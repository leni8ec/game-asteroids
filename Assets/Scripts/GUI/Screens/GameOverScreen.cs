using Asteroids.Core.World.Score;
using Asteroids.GUI.Base;
using TMPro;

namespace Asteroids.GUI.Screens {
    public class GameOverScreen : GuiMono {
        public TextMeshProUGUI score;

        private ScoreState scoreState;

        private void Awake() {
            scoreState = GetState<ScoreState>();
        }

        private void OnEnable() {
            score.text = $"Score\n{scoreState.Points.Value}";
        }
    }
}