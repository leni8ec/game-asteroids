using Asteroids.Core.World.Score;
using Asteroids.GUI.Base;
using JetBrains.Annotations;
using TMPro;

namespace Asteroids.GUI.Screens {

    public class GameOverScreen : View {
        public TextMeshProUGUI score;

        public void SetScorePoints(int value) {
            score.text = $"Score\n{value}";
        }

    }


    [UsedImplicitly]
    internal class GameOverScreenPresenter : Presenter<GameOverScreen> {

        public override void Construct() {
            ScoreState scoreState = GetState<ScoreState>();

            Subscribe(scoreState.Points, View.SetScorePoints);
        }

        protected override void OnEnableView() { }

        protected override void OnDisableView() { }

    }
}