using System;
using System.Collections.Generic;
using Asteroids.Framework.Entity;

namespace Asteroids.Framework.Pool {
    public class Pool<T> : IPool<T> where T : IEntity {

        public int InitialCapacity { get; }
        public bool IsEmpty => pool.Count == 0;

        /// <summary>
        /// Entities pool
        /// </summary>
        private readonly Stack<T> pool;

        /// Factory method to create item
        private readonly Func<T> factoryMethod;

        public Pool(Func<T> factoryMethod, int initialCapacity = 10) {
            InitialCapacity = initialCapacity;
            this.factoryMethod = factoryMethod;
            pool = new Stack<T>(initialCapacity);
        }

        public T Take() {
            return IsEmpty ? factoryMethod() : pool.Pop();
        }

        public void Return(T element) {
            pool.Push(element);
        }

    }
}