using System;
using System.Collections.Generic;
using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Common.Services.Spawner.Extra;

namespace Asteroids.Core.World.Entities.State.Objects {
    public class ActiveEntities /*: IEnumerable<EntityBase>*/ {

        /// All active entities as dict (include player)
        public IReadOnlyDictionary<Type, IReadOnlyDynamicList<EntityBase>> Dict => dict;
        private readonly Dictionary<Type, IReadOnlyDynamicList<EntityBase>> dict = new();

        /// All active entities as list (include player at the first index)
        public IReadOnlyList<IReadOnlyDynamicList<EntityBase>> List => list;
        private readonly List<IReadOnlyDynamicList<EntityBase>> list = new();


        public IReadOnlyDynamicList<EntityBase> Get<T>() where T : EntityBase {
            return dict[typeof(T)];
        }

        public IReadOnlyDynamicList<T> GetConcrete<T>() where T : EntityBase {
            return dict[typeof(T)] as IReadOnlyDynamicList<T>;
        }

        public void Add<T>(IReadOnlyDynamicList<T> entities) where T : EntityBase {
            list.Add(entities); // add to list firstly (memory stack?)
            dict[typeof(T)] = entities;
        }


    #region For Each

        // todo-later: Realize foreach
        // - add filters by entity types

        // public void ForEach<T>(Action<T> action) where T : EntityBase, new() { }
        //
        // public IEnumerator<EntityBase> GetEnumerator() {
        //     yield break;
        // }
        //
        // IEnumerator IEnumerable.GetEnumerator() {
        //     return GetEnumerator();
        // }

    #endregion


    }
}