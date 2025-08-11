using Asteroids.Core.Actors.Common;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo.LaserRay {

    public interface ILaserRayState : IEntityViewState {
        float Duration { get; }
    }


    public class LaserRayState : EntityState, ILaserRayState {

        [field: SerializeField] public float Duration { get; internal set; }

        protected override void OnReset() {
            Duration = default;
        }

    }

}