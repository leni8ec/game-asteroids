using Asteroids.Framework.Behavior;
using Asteroids.Framework.State;

namespace Asteroids.Framework.Systems {
    /// System with its own controlled state (that reset with the system reset)
    public class System<TState> : SystemBase, IReset where TState : IState {

        /// Default state of the system
        protected TState State { get; }

        protected System(TState state) {
            State = state;
        }

        /// Reset system state
        public void Reset() {
            State.Reset();
        }

    }
}