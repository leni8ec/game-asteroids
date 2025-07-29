using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Ufo;
using Asteroids.Core.Actors.Player;
using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Core.Actors.Weapons.Arms.Laser;
using Asteroids.Core.World.Audio;
using Asteroids.Core.World.Common.Config;
using Asteroids.Framework.Common;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Content.Index;
using Asteroids.Framework.DI.Context;
using UnityEngine;

namespace Asteroids.Core.World.Common.Context {

    public class WorldConfigsIndex : ContentIndex<IConfig> { }

    [CreateAssetMenu(menuName = "Configs/World Configs Context")]
    public class WorldConfigsContext : ScriptableObject, ICatalog<WorldConfigsIndex>, IDependencyContext {

        [Header("Game")]
        [SerializeField] private LevelConfig level;
        [SerializeField] private ScreenConfig screen;

        [Header("Entities")]
        [SerializeField] private PlayerConfig player;
        [SerializeField] private BulletConfig bullet;
        [SerializeField] private LaserConfig laser;

        [Space]
        [SerializeField] private AsteroidConfig asteroidLarge;
        [SerializeField] private AsteroidConfig asteroidMedium;
        [SerializeField] private AsteroidConfig asteroidSmall;
        [Space]
        [SerializeField] private UfoConfig ufo;

        [Header("Catalogs")]
        [SerializeField] private SoundsCatalog sounds;


        public WorldConfigsIndex GetContents() {
            WorldConfigsIndex index = new();

            index.Add(player);
            index.Add(bullet);
            index.Add(laser);

            index.Add(asteroidLarge, AsteroidSize.Large);
            index.Add(asteroidMedium, AsteroidSize.Medium);
            index.Add(asteroidSmall, AsteroidSize.Small);
            index.Add(ufo);

            index.Add(level);
            index.Add(screen);
            index.Add(sounds);

            return index;
        }

        public void InstallTo(IDependencyContainer container) {
            GetContents().InstallTo(container);
        }
    }
}