using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Common.Values;
using Asteroids.Core.World.Entities.State;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Game {
    [UsedImplicitly]
    public class GameStateSystem : SystemBase, IGameStateSystem, IStartSystem {
        private GameState State { get; }
        private EntitiesState Entities { get; }


    #region Boilerplate

        public GameStateSystem(GameState state, EntitiesState entities) {
            State = state;
            Entities = entities;
        }

        protected override void OnEnableSystem() {
            State.LevelActiveFlag.Changed += LevelActiveFlagHandler;
            Entities.KillEvent += EntitiesKillEventHandler;
        }


        protected override void OnDisableSystem() {
            State.LevelActiveFlag.Changed -= LevelActiveFlagHandler;
            Entities.KillEvent -= EntitiesKillEventHandler;
        }

        private void EntitiesKillEventHandler(IEntity killedEntity) {
            if (killedEntity is Player) OnPlayerKilled();
        }

        private void LevelActiveFlagHandler(bool active) {
            if (active) OnLevelStart();
            else OnLevelEnd();
        }

    #endregion


        public void Start() {
            // Start "New Game" automatically on system start
            State.LevelActiveFlag.Enable();
        }

        private void OnPlayerKilled() {
            State.LevelActiveFlag.Disable();
        }

        private void OnLevelStart() {
            if (State.Status == GameStatus.Play) return;
            State.Status.Value = GameStatus.Play;
        }

        private void OnLevelEnd() {
            if (State.Status == GameStatus.End) return;
            State.Status.Value = GameStatus.End;
        }

    }
}