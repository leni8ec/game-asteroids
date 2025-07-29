using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;
using UnityEngine;

namespace Asteroids.Core.World.Scene {
    public class SceneContext : MonoBehaviour, IDependencyContext {

        [Space] [SerializeField]
        private SceneAdaptersContext sceneAdapters;


        public void InstallTo(IDependencyContainer container) {
            sceneAdapters.InstallTo(container);
        }
    }
}