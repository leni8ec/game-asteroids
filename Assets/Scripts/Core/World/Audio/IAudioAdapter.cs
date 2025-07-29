using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Audio {
    public interface IAudioAdapter : IAdapter {

        void PlaySound(AudioClip clip);

    }
}