using Asteroids.Framework.Reactive;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Score {
    public class ScoreState : IState {

        public ReactiveProperty<int> Points { get; } = new();

        public void Reset() {
            Points.ResetQuietly();
        }

    }
}