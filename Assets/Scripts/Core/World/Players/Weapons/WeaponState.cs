using System;
using Asteroids.Framework.Reactive;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Players.Weapons {
    public class WeaponState : IState {

        // Input state
        /// <summary>
        /// Active weapons (from input)
        /// </summary>
        public Weapon ActiveWeapons { get; internal set; }

        // Countdowns
        public float Fire1Countdown { get; internal set; }
        public float Fire2Countdown { get; internal set; }

        // Laser data
        public float LaserRefillCountdown { get; internal set; }
        public ReactiveInt LaserShotsCount { get; private set; } = new();


        // Events
        public event FireEvent Fire1Event;
        public event FireEvent Fire2Event;


        public void Reset() {
            ActiveWeapons = default;
            Fire1Countdown = default;
            Fire2Countdown = default;
            LaserRefillCountdown = default;
            LaserShotsCount.ResetQuietly();

            // Fire1Event = default;
            // Fire2Event = default;
        }

        public void RegisterFire1Publisher(out FireEvent publisher) {
            publisher = () => Fire1Event?.Invoke();
        }

        public void RegisterFire2Publisher(out FireEvent publisher) {
            publisher = () => Fire2Event?.Invoke();
        }

    }


    public delegate void FireEvent();

    [Flags]
    public enum Weapon {
        Empty = 0,
        Gun = 1 << 0,
        Laser = 1 << 1
    }

}