using Asteroids.Core.World.Audio;
using Asteroids.Core.World.Camera;
using Asteroids.Framework.Common;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Content.Index;
using Asteroids.Framework.DI.Context;
using UnityEngine;

namespace Asteroids.Core.World.Scene {
    public class SceneAdaptersIndex : ContentIndex<IAdapter> { }

    public class SceneAdaptersContext : MonoBehaviour, ICatalog<SceneAdaptersIndex>, IDependencyContext {

        [Space]
        [SerializeField] private new UnityCameraAdapter camera;
        [SerializeField] private new UnityAudioAdapter audio;

        public SceneAdaptersIndex GetContents() {
            SceneAdaptersIndex index = new();

            // => Use concrete adapter interfaces explicitly!
            index.Add<ICameraAdapter>(camera);
            index.Add<IAudioAdapter>(audio);

            return index;
        }

        public void InstallTo(IDependencyContainer container) {
            GetContents().InstallTo(container);
        }
    }
}