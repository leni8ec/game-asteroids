﻿using Core.Interface.Objects;
using Core.Pools;
using Core.State;
using Core.Unity;
using Domain.Base;

namespace Domain.Systems {
    public class ObjectsUpdateSystem : SystemBase, IUpdateSystem {
        private ObjectsState State { get; }

        private bool active;

        public ObjectsUpdateSystem(StateCollector state, ConfigCollector config, PrefabCollector prefab) {
            State = state.objects;

            // Game state listeners
            GameStateSystem.NewGameEvent += Play;
            GameStateSystem.GameOverEvent += Reset;
        }

        private void Play() {
            active = true;
        }

        private void Reset() {
            active = false;
        }


        public void Upd(float deltaTime) {
            if (!active) return;

            // Update Player
            State.player.Upd(deltaTime);

            // Update Enemies
            State.ufosPool.ForEachActive(UpdEntity);
            foreach (AsteroidPool asteroidPool in State.asteroidPools.Values)
                asteroidPool.ForEachActive(UpdEntity);

            // Update Ammo
            State.ammo1Pool.ForEachActive(UpdEntity);
            State.ammo2Pool.ForEachActive(UpdEntity);

            return;
            void UpdEntity(IEntity entity) => entity.Upd(deltaTime);
        }

    }
}