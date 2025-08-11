using Asteroids.Core.Actors.Common;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    public class Ufo : Enemy<UfoState, UfoConfig>, IUfo {

        protected override void OnSpawned() {
            State.HuntCountdown = Config.HuntDelay;
            State.Speed = Config.StartSpeed;

        }

        public void SetTarget(EntityBase target) {
            State.Target = target;
        }

        public void StartHunt() {
            State.hunting.Enable();
            State.Speed = Config.HuntSpeed;
        }

        public override void Upd(float deltaTime) {
            if (!State.hunting) {
                State.HuntCountdown -= Time.deltaTime;
                if (State.HuntCountdown < 0) StartHunt();
            } else {
                State.direction = -(Transform.position - State.Target.Position).normalized;
            }

            Transform.Translate(State.direction * (State.Speed * deltaTime));
        }

    }
}