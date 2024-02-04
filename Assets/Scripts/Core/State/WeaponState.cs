﻿using System;
using Core.Base;

namespace Core.State {
    public class WeaponState : IStateData {

        #region Input state

        /// <summary>
        /// State - Weapon
        /// </summary>
        public ValueChange<Weapon> FireState { get; } = new();

        #endregion

        public float fire1Countdown;
        public float fire2Countdown;

        // Laser data
        public float laserShotCountdownDuration;
        public float laserShotsCount;


        [Flags]
        public enum Weapon {
            Empty = 0,
            Gun = 1 << 0,
            Laser = 1 << 1
        }

        public void Reset() {
            FireState.Reset();
            fire1Countdown = 0;
            fire2Countdown = 0;
            laserShotCountdownDuration = 0;
            laserShotsCount = 0;
        }

    }
}