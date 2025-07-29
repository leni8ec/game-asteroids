using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Asteroid {
    public class AsteroidState : EntityState, IDirectionContainer {

        [field: SerializeField]
        public Vector3 Direction { get; set; }

        protected override void OnReset() {
            Direction = default;
        }

    }
}