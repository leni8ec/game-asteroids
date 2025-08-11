using System.Collections.Generic;
using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Services.Spawner.Extra;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Entities.State.Objects;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Entities.Systems {
    [UsedImplicitly]
    public class EntityUpdateSystem : SystemBase, IEntityUpdateSystem, IUpdateSystem {
        private ActiveEntities Active { get; }

        List<IReadOnlyDynamicList<IEntity>> activeEntities;

        public EntityUpdateSystem(EntitiesState entities, GameState gameState) {
            Active = entities.Active;

            // Game state events
            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }


        public void UpdateSystem(float deltaTime) {

            foreach (var entities in Active.List) {
                entities.ForEachDynamic(UpdEntity);
            }

            return;
            void UpdEntity(IEntity entity) => entity.Upd(deltaTime);
        }

    }
}