using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Ufo;
using Asteroids.Core.Actors.Player;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.World.Camera;
using Asteroids.Core.World.Common.Config;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Entities.State.Objects;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;
using UnityEngine;

namespace Asteroids.Core.World.Screen {
    [UsedImplicitly]
    public class InfinityScreenSystem : SystemBase, IInfinityScreenSystem, IUpdateSystem {
        private ScreenConfig Config { get; }
        private ICameraAdapter Camera { get; }
        private ActiveEntities Active { get; }

        public InfinityScreenSystem(ScreenConfig config, ICameraAdapter cameraAdapter, EntitiesState entities) {
            Config = config;
            Camera = cameraAdapter;
            Active = entities.Active;
        }

        public void UpdateSystem(float deltaTime) {
            ProcessInfinityScreen();
        }

        private void ProcessInfinityScreen() {
            Rect worldBorders = Camera.GetWorldLimits(Config.ScreenInfinityOutsideOffset);

            // Player
            Active.Get<Player>().ForEachDynamic(ProcessEntity);

            // Enemies
            Active.Get<Ufo>().ForEachDynamic(ProcessEntity);
            Active.Get<Asteroid>().ForEachDynamic(ProcessEntity);

            // Bullets
            Active.Get<Bullet>().ForEachDynamic(ProcessEntity);

            return;
            void ProcessEntity(EntityBase entity) => ProcessEntityOutOfScreen(worldBorders, entity);
        }

        private void ProcessEntityOutOfScreen(Rect worldBorders, EntityBase entity) {
            Vector3 newPos = entity.Position;
            if (worldBorders.Contains(newPos)) return;

            if (newPos.x < worldBorders.x) newPos.x = worldBorders.xMax;
            else if (newPos.y < worldBorders.y) newPos.y = worldBorders.yMax;
            else if (newPos.x > worldBorders.xMax) newPos.x = worldBorders.x;
            else if (newPos.y > worldBorders.yMax) newPos.y = worldBorders.y;

            entity.Position = newPos;
        }


    }
}