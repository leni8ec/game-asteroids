using Asteroids.Core.Actors.Player;
using Asteroids.Core.Actors.Weapons.Ammo.Bullet;
using Asteroids.Core.Actors.Weapons.Ammo.LaserRay;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Services.Spawner.Extra;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Weapon {
    // todo-later: find solution for implementing weapon slots (1 and 2) - use strategy pattern
    [UsedImplicitly]
    public class WeaponSystem : SystemBase, IWeaponSystem, IUpdateSystem {
        private WeaponState State { get; }
        private BulletConfig Ammo1Config { get; }
        private LaserConfig Ammo2Config { get; }

        private BulletSpawner Ammo1Spawner { get; }
        private LaserSpawner Ammo2Spawner { get; }
        private EntitiesState Entities { get; }

        private IReadOnlyDynamicList<IEntity> ActiveAmmo1 { get; }
        private IReadOnlyDynamicList<IEntity> ActiveAmmo2 { get; }

        private float Fire1Delay => 1 / Ammo1Config.FireRate;
        private float Fire2Delay => 1 / Ammo2Config.FireRate;

        private readonly FireEvent fire1EventPublisher;
        private readonly FireEvent fire2EventPublisher;

        private Player player;

        public WeaponSystem(WeaponState state,
            BulletConfig bulletConfig, LaserConfig laserConfig,
            BulletSpawner bulletSpawner, LaserSpawner laserSpawner,
            EntitiesState entities, GameState gameState
        ) {
            State = state;
            Entities = entities;

            ActiveAmmo1 = entities.Active.Get<Bullet>();
            ActiveAmmo2 = entities.Active.Get<Laser>();

            // Link properties
            Ammo1Spawner = bulletSpawner;
            Ammo2Spawner = laserSpawner;

            Ammo1Config = bulletConfig;
            Ammo2Config = laserConfig;

            State.RegisterFire1Publisher(out fire1EventPublisher);
            State.RegisterFire2Publisher(out fire2EventPublisher);

            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        protected override void OnEnableSystem() {
            State.laserRefillCountdown = Ammo2Config.ShotRefillDuration;
            player = Entities.Player;
        }

        protected override void OnDisableSystem() {
            State.Reset();
            player = null;
        }

        public void UpdateSystem(float deltaTime) {
            bool fired = State.activeWeapons != Weapon.Empty;
            if (fired && State.activeWeapons.HasFlag(Weapon.Gun) && State.fire1Countdown <= 0) {
                State.fire1Countdown = Fire1Delay;
                Fire1();
            }

            if (fired && State.activeWeapons.HasFlag(Weapon.Laser) && State.fire2Countdown <= 0 && State.laserShotsCount > 0) {
                State.fire2Countdown = Fire2Delay;
                State.laserShotsCount--;
                Fire2();
            }

            if (State.fire1Countdown > 0) State.fire1Countdown -= deltaTime;
            if (State.fire2Countdown > 0) State.fire2Countdown -= deltaTime;

            // Laser
            if (State.laserShotsCount < Ammo2Config.MaxShotsCount) {
                if ((State.laserRefillCountdown -= deltaTime) <= 0) {
                    State.laserRefillCountdown = Ammo2Config.ShotRefillDuration;
                    State.laserShotsCount++;
                }
            }

        }

        private void Fire1() {
            Ammo1Spawner.Spawn(player.WeaponWorldPosition, player.Forward);
            fire1EventPublisher();
        }

        private void Fire2() {
            Ammo2Spawner.Spawn(player.WeaponWorldPosition, player.Forward);
            fire2EventPublisher();
        }
    }
}