﻿using System;
using Model.Data.State;
using Model.Data.Unity.Config;
using Model.Entity.Base;
using Model.Entity.Interface;

namespace Model.Entity {
    public class Laser : Ammo<LaserAmmoState, LaserConfig>, ILaser {

        public float MaxDistance => Config.maxDistance;

        public event Action FireEvent;


        public void Fire() {
            State.duration = Config.duration;
            Transform.up = State.Direction;

            FireEvent?.Invoke();
        }

        public override void Upd(float deltaTime) {
            if ((State.duration -= deltaTime) < 0) {
                Destroy();
            }
        }

    }
}