using Asteroids.Core.World.Common.Context;
using UnityEngine;

namespace Asteroids.Application.Bootstrapper.Config {
    [CreateAssetMenu(menuName = "Configs/Project Start Config")]
    public class ProjectConfig : ScriptableObject {

        public const string RESOURCE_PATH = "Project/Project Config";

        [field: Space]
        [field: SerializeField] public WorldConfigsContext WorldConfigs { get; private set; }

    }
}