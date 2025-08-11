using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Enemies;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Systems;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Score {
    [UsedImplicitly]
    public class ScoreSystem : SystemBase, IScoreSystem {
        private ScoreState State { get; }
        private EntitiesState Entities { get; }


    #region Boilerplate

        public ScoreSystem(ScoreState state, GameState gameState, EntitiesState entities) {
            State = state;
            Entities = entities;

            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        protected override void OnEnableSystem() {
            State.Reset(); // Reset scores on level start
            Entities.KillEvent += KillEventHandler;
        }

        protected override void OnDisableSystem() {
            Entities.KillEvent -= KillEventHandler;
        }

        private void KillEventHandler(IEntity entity) {
            if (entity is IEnemy) OnKillEnemy();
        }

    #endregion


        private void OnKillEnemy() {
            State.Points.Value++;
        }

    }
}