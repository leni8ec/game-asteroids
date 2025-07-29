using Asteroids.Core.World.Common.Values;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Game {
    // todo-later: Maybe a 'LevelState' ?
    public class GameState : IState {

        /// 'true' - on new game <br/> 'false' - on end game
        public ReactiveFlag LevelActiveFlag { get; } = new();

        public ReactiveProperty<GameStatus> Status { get; } = new();


        public void Reset() {
            LevelActiveFlag.ResetValueQuietly();
            Status.ResetValueQuietly();
        }

    }
}