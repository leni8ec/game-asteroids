using Asteroids.Core.Actors.Common;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    public class UfoView : EntityView<IUfoState, UfoConfig> {
        [SerializeField] private AudioSource normalAudio;
        [SerializeField] private AudioSource huntAudio;

        protected override void SubscribeEvents() {
            State.Hunting.Enabled += StartHunting;
            State.Active.Disabled += DisableHandler;
        }

        private void DisableHandler() {
            huntAudio.Stop();
        }

        private void StartHunting() {
            normalAudio.Stop();
            huntAudio.Play();
        }

    }
}