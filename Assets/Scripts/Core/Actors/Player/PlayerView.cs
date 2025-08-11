using Asteroids.Core.Actors.Common;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {
    public class PlayerView : EntityView<IPlayerState, PlayerConfig> {
        [Space]
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite idleSprite;
        [SerializeField] private Sprite moveSprite;
        [Space]
        [SerializeField] private AudioSource moveAudio;

        protected override void SubscribeEvents() {
            State.Move.Changed += OnMoveStateChanged;
        }

        private void OnMoveStateChanged(bool moveFlag) {
            if (moveFlag) {
                moveAudio.Play();
                spriteRenderer.sprite = moveSprite;
            } else {
                moveAudio.Stop();
                spriteRenderer.sprite = idleSprite;
            }
        }

    }
}