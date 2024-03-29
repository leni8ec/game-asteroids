﻿using Model.Data.Unity.Config;
using Model.Entity;
using Model.Entity.Interface;
using UnityEngine;
using UnityView.Entity;

namespace UnityView.Binders {
    public class UnityAsteroidCreateListener : UnityEntityCreateListener<AsteroidView> {
        private readonly GameObject largePrefab;
        private readonly GameObject mediumPrefab;
        private readonly GameObject smallPrefab;

        public UnityAsteroidCreateListener(GameObject largePrefab, GameObject mediumPrefab, GameObject smallPrefab) : base(null) {
            this.largePrefab = largePrefab;
            this.mediumPrefab = mediumPrefab;
            this.smallPrefab = smallPrefab;
        }

        public override void OnCreate(IEntity entity) {
            AsteroidConfig.Size asteroidSize = ((Asteroid) entity).Size;
            prefab = asteroidSize switch {
                AsteroidConfig.Size.Large => largePrefab,
                AsteroidConfig.Size.Medium => mediumPrefab,
                AsteroidConfig.Size.Small => smallPrefab,
                _ => null
            };

            // Create Asteroid with new prefab
            base.OnCreate(entity);
        }


    }
}