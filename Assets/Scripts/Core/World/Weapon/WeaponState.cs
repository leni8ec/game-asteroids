using System;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Weapon {
    public class WeaponState : IState {

        // Input state
        /// <summary>
        /// Active weapons (from input)
        /// </summary>
        public Weapon activeWeapons;

        // Countdowns
        public float fire1Countdown;
        public float fire2Countdown;

        // Laser data
        public float laserRefillCountdown;
        public float laserShotsCount;


        // Events
        public event FireEvent Fire1Event;
        public event FireEvent Fire2Event;


        public void Reset() {
            activeWeapons = default;
            fire1Countdown = default;
            fire2Countdown = default;
            laserRefillCountdown = default;
            laserShotsCount = default;

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