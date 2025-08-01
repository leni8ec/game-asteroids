using UnityEngine;

namespace Asteroids.Framework.Entity.Services.Factory {

    /// Entity container for created GameObjects on unity scene
    public class EntityContainer {

        private const string ROOT_NAME = "World";
        private static Transform _root;

        private readonly Transform container;

        /// <inheritdoc cref="EntityContainer"/>
        /// <param name="containerName">
        /// parent container name for game objects
        /// <br/> - leave <b>null</b> to use a default root container
        /// <br/> - or specify <b>name</b> to use own named container under root
        /// </param>
        public EntityContainer(string containerName = null) {
            if (!_root) _root = new GameObject(ROOT_NAME).transform;
            if (containerName == null) {
                container = _root;
                return;
            }

            container = _root.Find(containerName);
            if (container) return;

            container = new GameObject(containerName).transform;
            container.parent = _root;
        }

        public void Add(GameObject go) {
            go.transform.parent = container;
        }

    }
}