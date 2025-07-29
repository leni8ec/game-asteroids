using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo.Bullet {
    public class BulletState : EntityState, IDirectionContainer {

        public float lifetime;
        [field: SerializeField]
        public Vector3 Direction { get; set; }

        protected override void OnReset() {
            lifetime = default;
            Direction = default;
        }

    }
}