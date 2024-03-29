﻿using Core.Framework.Systems;
using Core.Systems.Interface;
using JetBrains.Annotations;
using Model.Behavior;
using Model.Data.EntityPool;
using Model.Data.State;
using Model.Data.Unity.Config;
using Model.Entity;

namespace Core.Systems {
    [UsedImplicitly]
    public class WeaponSystem : SystemBase, IWeaponSystem, IUpdateSystem {
        private WeaponSystemState State { get; }
        private BulletConfig Ammo1Config { get; }
        private LaserConfig Ammo2Config { get; }

        private EntitiesManager<Bullet, BulletAmmoState, BulletConfig> Ammo1Manager { get; }
        private EntitiesManager<Laser, LaserAmmoState, LaserConfig> Ammo2Manager { get; }

        private IEntitiesList<Bullet> ActiveAmmo1 { get; }
        private IEntitiesList<Laser> ActiveAmmo2 { get; }

        private float Fire1Delay => 1 / Ammo1Config.fireRate;
        private float Fire2Delay => 1 / Ammo2Config.fireRate;

        // Events
        public delegate void FireEvent();
        public static event FireEvent Fire1Event;
        public static event FireEvent Fire2Event;

        private Player Player { get; }

        public WeaponSystem(WeaponSystemState state, BulletConfig bulletConfig, LaserConfig laserConfig,
            ActiveEntitiesState activeEntities, EntitiesManagersState entitiesManagers) {
            State = state;
            Player = activeEntities.player;

            ActiveAmmo1 = activeEntities.ammo1;
            ActiveAmmo2 = activeEntities.ammo2;

            // Link properties
            Ammo1Manager = entitiesManagers.ammo1;
            Ammo2Manager = entitiesManagers.ammo2;

            Ammo1Config = bulletConfig;
            Ammo2Config = laserConfig;

            // Game state events
            GameStateSystem.NewGameEvent += Play;
            GameStateSystem.GameOverEvent += Reset;
        }

        private void Play() {
            Enable();
            State.laserShotCountdownDuration = Ammo2Config.shotRestoreCountdown;
        }

        private void Reset() {
            Disable();
            State.Reset();

            // Destroy Ammo
            ActiveAmmo1.ForEachSave(Destroy);
            ActiveAmmo2.ForEachSave(Destroy);

            return;
            void Destroy(IDestroy entity) => entity.Destroy();
        }

        public void Upd(float deltaTime) {
            bool fired = State.fireStatus != WeaponSystemState.Weapon.Empty;
            if (fired && State.fireStatus.HasFlag(WeaponSystemState.Weapon.Gun) && State.fire1Countdown <= 0) {
                State.fire1Countdown = Fire1Delay;
                SpawnBullet();
                Fire1Event?.Invoke();
            }

            if (fired && State.fireStatus.HasFlag(WeaponSystemState.Weapon.Laser) && State.fire2Countdown <= 0 && State.laserShotsCount > 0) {
                State.fire2Countdown = Fire2Delay;
                State.laserShotsCount--;
                SpawnLaser();
                Fire2Event?.Invoke();
            }

            if (State.fire1Countdown > 0) State.fire1Countdown -= deltaTime;
            if (State.fire2Countdown > 0) State.fire2Countdown -= deltaTime;

            // Laser
            if (State.laserShotsCount < Ammo2Config.maxShotsCount) {
                if ((State.laserShotCountdownDuration -= deltaTime) <= 0) {
                    State.laserShotCountdownDuration = Ammo2Config.shotRestoreCountdown;
                    State.laserShotsCount++;
                }
            }

        }

        private void SpawnBullet() {
            Bullet bullet = Ammo1Manager.TakeEntity();
            bullet.Set(Player.WeaponWorldPosition, Player.Forward);
            bullet.Fire();
        }

        private void SpawnLaser() {
            Laser laser = Ammo2Manager.TakeEntity();
            laser.Set(Player.Position, Player.Forward);
            laser.Fire();
        }
    }
}