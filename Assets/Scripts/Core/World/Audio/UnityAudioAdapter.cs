using UnityEngine;

namespace Asteroids.Core.World.Audio {
    public class UnityAudioAdapter : MonoBehaviour, IAudioAdapter {

        [SerializeField]
        private AudioSource audioSource;

        public void PlaySound(AudioClip clip) {
            if (!clip) {
                Debug.LogError("AudioClip is null!");
                return;
            }

            audioSource.PlayOneShot(clip);
        }

    }
}