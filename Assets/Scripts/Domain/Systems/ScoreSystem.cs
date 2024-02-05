﻿using Core.Interface.Objects;
using Core.State;
using Core.Unity;
using Domain.Base;

namespace Domain.Systems {
    public class ScoreSystem : SystemBase {
        private ScoreState State { get; }

        public ScoreSystem(StateCollector state, ConfigCollector config, PrefabCollector prefab) {
            State = state.score;

            CollisionSystem.EnemyHit += EnemyHitHandler;
            GameStateSystem.NewGameEvent += ResetHandler;
        }

        private void ResetHandler() {
            State.Points.Value = 0;
        }

        private void EnemyHitHandler(ICollider enemy, ICollider ammo) {
            State.Points.Value++;
        }

    }
}