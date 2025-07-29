using System;
using System.Collections.Generic;

namespace Asteroids.Framework.Entity.Services.Spawner.Extra {
    public class DynamicList<T> : List<T>, IReadOnlyDynamicList<T> {

        public DynamicList(int capacity) : base(capacity) { }

        public void ForEachDynamic(Action<T> action) {
            for (int i = Count - 1; i >= 0; i--) {
                action(this[i]);
            }
        }


    }
}