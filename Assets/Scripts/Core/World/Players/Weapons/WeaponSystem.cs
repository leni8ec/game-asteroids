using Asteroids.Core.Actors.Player;
using Asteroids.Core.Actors.Weapons.Ammo.Bullet;
using Asteroids.Core.Actors.Weapons.Ammo.LaserRay;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Players.Common;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;

namespace Asteroids.Core.World.Players.Weapons {
    // todo-later: find solution for implementing weapon slots (1 and 2) - use strategy pattern
    [UsedImplicitly]
    public class WeaponSystem : SystemBase, IWeaponSystem, IUpdateSystem {
        private WeaponState State { get; }
        private BulletConfig Ammo1Config { get; }
        private LaserConfig Ammo2Config { get; }

        private BulletSpawner Ammo1Spawner { get; }
        private LaserSpawner Ammo2Spawner { get; }
        private PlayersState Players { get; }

        private float Fire1Delay => 1 / Ammo1Config.FireRate;
        private float Fire2Delay => 1 / Ammo2Config.FireRate;

        private readonly FireEvent fire1EventPublisher;
        private readonly FireEvent fire2EventPublisher;

        public WeaponSystem(WeaponState state,
            BulletConfig bulletConfig, LaserConfig laserConfig,
            BulletSpawner bulletSpawner, LaserSpawner laserSpawner,
            PlayersState players, GameState gameState
        ) {
            State = state;
            Players = players;

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
            State.LaserRefillCountdown = Ammo2Config.ShotRefillDuration;
        }

        protected override void OnDisableSystem() {
            State.Reset();
        }

        public void UpdateSystem(float deltaTime) {
            bool fired = State.ActiveWeapons != Weapon.Empty;
            if (fired && State.ActiveWeapons.HasFlag(Weapon.Gun) && State.Fire1Countdown <= 0) {
                State.Fire1Countdown = Fire1Delay;
                Fire1();
            }

            if (fired && State.ActiveWeapons.HasFlag(Weapon.Laser) && State.Fire2Countdown <= 0 && State.LaserShotsCount > 0) {
                State.Fire2Countdown = Fire2Delay;
                State.LaserShotsCount.Value--;
                Fire2();
            }

            if (State.Fire1Countdown > 0) State.Fire1Countdown -= deltaTime;
            if (State.Fire2Countdown > 0) State.Fire2Countdown -= deltaTime;

            // Laser
            if (State.LaserShotsCount < Ammo2Config.MaxShotsCount) {
                if ((State.LaserRefillCountdown -= deltaTime) <= 0) {
                    State.LaserRefillCountdown = Ammo2Config.ShotRefillDuration;
                    State.LaserShotsCount.Value++;
                }
            }

        }

        private void Fire1() {
            Player player = Players.Active;
            Ammo1Spawner.Spawn(player.WeaponWorldPosition, player.Forward);
            fire1EventPublisher();
        }

        private void Fire2() {
            Player player = Players.Active;
            Ammo2Spawner.Spawn(player.WeaponWorldPosition, player.Forward);
            fire2EventPublisher();
        }
    }
}