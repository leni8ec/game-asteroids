using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Entities.State.Objects;
using Asteroids.Framework.Entity;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Entities.State {
    public class EntitiesState : IState {

        public event EntityKillEvent KillEvent;

        public ActiveEntities Active { get; } = new();

        // todo-consider: need to investigate it (maybe find a more reliable solution)
        // - use 'Lazy<>' in Systems ?
        ///  Active Player
        public Player Player { get; set; }


        public void Reset() {
            KillEvent = null;
            Player = null;
        }

        public void RegisterEntityKillPublisher(out EntityKillEvent publisher) {
            publisher = entity => KillEvent?.Invoke(entity);
        }

    }

    public delegate void EntityKillEvent(IEntity killedEntity);

}