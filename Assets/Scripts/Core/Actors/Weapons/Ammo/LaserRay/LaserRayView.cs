using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo.LaserRay {
    public class LaserRayView : EntityView<LaserRayState, LaserConfig> {
        [SerializeField] private Transform scaledTransform;
        [SerializeField] private SpriteRenderer laserSprite;

        protected override void SubscribeEvents() {
            State.active.Enabled += FireHandle;
        }

        private void FireHandle() {
            // Set laser scale (visual)
            Vector3 scale = scaledTransform.localScale;
            scale.y = Config.MaxDistance;
            scaledTransform.localScale = scale;
        }

        private void Update() {
            Color color = laserSprite.color;
            color.a = Mathf.Max(0, State.Duration / Config.Duration);
            laserSprite.color = color;
        }

    }
}