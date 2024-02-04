﻿using UnityEngine;

namespace Core.Config {
    [CreateAssetMenu(menuName = "Data/AsteroidData")]
    public class AsteroidConfig : ScriptableObject, IConfigData {
        public float speed = 1f;
        [Tooltip("How many new smaller fragments on destroyed")]
        public int destroyFragments = 4;

        [Header("Collision")]
        public float colliderRadius = 0.1f;

    }

}