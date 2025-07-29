using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo.LaserRay {
    public class LaserRayState : EntityState, IDirectionContainer {

        public float duration;
        [field: SerializeField]
        public Vector3 Direction { get; set; }

        protected override void OnReset() {
            duration = default;
            Direction = default;
        }

    }
}