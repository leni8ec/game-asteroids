using Asteroids.Core.Actors.Common;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {
    public class Player : ColliderEntity<PlayerState, PlayerConfig>, IPlayer {

        public Vector3 WeaponWorldPosition => Transform.position + Transform.up * 0.2f;

        public bool Move { set => State.move.Value = value; }
        public float Rotate { set => State.Rotate = value; }

        public override void Upd(float deltaTime) {
            // Moving
            if (State.move) {
                if (State.InertialTime < 1) {
                    State.InertialTime = Mathf.Min(1, State.InertialTime + deltaTime * (1 / Config.AccelerationInertia));
                    State.InertialSpeed = Mathf.Lerp(0, Config.Speed, State.InertialTime);
                }
            } else {
                if (State.InertialTime > 0) {
                    State.InertialTime = Mathf.Max(0, State.InertialTime - deltaTime * (1 / Config.BrakingInertia));
                    State.InertialSpeed = Mathf.Lerp(0, Config.Speed, State.InertialTime);
                }
            }

            if (State.InertialTime > 0) {
                // transform.Translate(transform.up * (config.speed * deltaTime));
                if (State.move) {
                    State.direction = Vector3.Lerp(State.LastDirection, Transform.up, deltaTime / Config.LeftOverInertia); // leftover inertia
                } else {
                    State.direction = State.LastDirection; // don't change direction without acceleration
                }
                State.LastDirection = State.direction * State.InertialTime;

                Vector3 position = Transform.position;
                position += State.direction * (State.InertialSpeed * deltaTime);
                Transform.position = position;
            }


            // Rotation
            if (Mathf.Abs(State.Rotate) > 0.01f) {
                Transform.Rotate(0, 0, Config.RotationSpeed * deltaTime * State.Rotate);
            }

            // Calculate speed
            Vector3 pos = Transform.position;
            State.Speed = Vector3.Distance(State.LastPos, pos) / deltaTime;
            State.LastPos = pos;
        }

    }
}