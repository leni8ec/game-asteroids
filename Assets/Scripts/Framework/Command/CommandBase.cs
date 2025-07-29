using Asteroids.Framework.State;

namespace Asteroids.Framework.Command {
    public abstract class CommandBase<TState> : ICommand where TState : IState {
        protected TState State { get; }

        protected CommandBase(TState state) {
            State = state;
        }

    }
}