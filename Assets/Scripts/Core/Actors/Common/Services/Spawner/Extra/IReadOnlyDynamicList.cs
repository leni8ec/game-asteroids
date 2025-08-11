using System;
using System.Collections.Generic;

namespace Asteroids.Core.Actors.Common.Services.Spawner.Extra {
    public interface IReadOnlyDynamicList<out T> : IReadOnlyCollection<T> {

        public T this[int index] { get; }

        /// <summary>
        /// Iterate for all list elements.<br/><br/>
        /// It's safe for list changes during iteration.
        /// </summary>
        /// <remarks> Used in <see cref="Spawner{TEntity,TFactory}"/></remarks>
        public void ForEachDynamic(Action<T> action);

    }
}