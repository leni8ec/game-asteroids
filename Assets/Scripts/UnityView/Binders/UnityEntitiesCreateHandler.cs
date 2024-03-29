﻿using Model.Entity;
using Presenter.Binders;
using UnityView.Collectors;
using UnityView.Entity;

namespace UnityView.Binders {
    public class UnityEntitiesCreateHandler {

        public UnityEntitiesCreateHandler(UnityPrefabCollector prefab) {
            EntitiesCreateHandler entitiesCreateHandler = new();

            entitiesCreateHandler.AddListener<Player>(new UnityEntityCreateListener<PlayerView>(prefab.player));
            entitiesCreateHandler.AddListener<Bullet>(new UnityEntityCreateListener<BulletView>(prefab.bullet));
            entitiesCreateHandler.AddListener<Laser>(new UnityEntityCreateListener<LaserView>(prefab.laser));
            entitiesCreateHandler.AddListener<Ufo>(new UnityEntityCreateListener<UfoView>(prefab.ufo));
            // Asteroids has own logic
            entitiesCreateHandler.AddListener<Asteroid>(new UnityAsteroidCreateListener(prefab.asteroidLarge, prefab.asteroidMedium, prefab.asteroidSmall));

        }

    }
}