using Asteroids.Core.Actors.Common;
using Asteroids.Core.World.Entities.State.Objects;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Entities.State {
    public class EntitiesState : IState {

        public event EntityKillEvent KillEvent;

        public ActiveEntities Active { get; } = new();

        public void Reset() {
            KillEvent = null;
        }

        public void RegisterEntityKillPublisher(out EntityKillEvent publisher) {
            publisher = entity => KillEvent?.Invoke(entity);
        }

    }

    public delegate void EntityKillEvent(IEntity killedEntity);

}