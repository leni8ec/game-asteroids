using Asteroids.Framework.Entity;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    public class Ufo : Enemy<UfoState, UfoConfig>, IUfo {


        public void StartHunt() {
            State.Hunting.Enable();
        }

        public void SetTarget(EntityBase target) {
            State.target = target;
            State.huntCountdown = Config.HuntDelay;
        }

        public override void Upd(float deltaTime) {
            if ((State.huntCountdown -= Time.deltaTime) > 0) {
                Transform.Translate(State.Direction * (Config.StartSpeed * deltaTime));
            } else {
                if (!State.Hunting) {
                    StartHunt();
                }
                Vector3 huntDirection = -(Transform.position - State.target.Position).normalized;
                Transform.Translate(huntDirection * (Config.HuntSpeed * deltaTime));
            }
        }

    }
}