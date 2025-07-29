using System;
using Asteroids.Framework.Entity;
using Asteroids.Framework.Entity.Containers;
using Asteroids.Framework.Reactive;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    [Serializable]
    public class UfoState : EntityState, IDirectionContainer {

        public ReactiveFlag Hunting { get; private set; } = new();
        public float huntCountdown;

        public EntityBase target;
        [field: SerializeField]
        public Vector3 Direction { get; set; }


        protected override void OnReset() {
            Hunting.ResetValueQuietly();
            huntCountdown = default;
            target = default;
            Direction = default;
        }

    }
}