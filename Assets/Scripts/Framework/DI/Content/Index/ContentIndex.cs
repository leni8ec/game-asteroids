using System;
using System.Collections.Generic;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Content.Bunch;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Framework.DI.Content.Index {

    /// <inheritdoc cref="IContentIndex"/>
    public abstract class ContentIndex<TObject> : IContentIndex, IDependencyContext {

        private readonly IDictionary<Type, TObject> entries = new Dictionary<Type, TObject>();
        // public IDictionary<Type, TObject> Entries => entries;

        public T Get<T>() where T : TObject {
            return (T) entries[typeof(T)];
        }

        public void Add<T>(T obj) where T : TObject {
            entries.Add(typeof(T), obj);
        }


    #region Inserts

        private readonly InsertSet<object, TObject> insertSet = new();
        // public InsertSet<object, TObject> InsertSet => insertSet;

        private bool HasInserts => insertSet.Count > 0;

        // => Get - not used
        // public T Get<T, TKey>(TKey key) where T : TObject {
        //     return (T) insertSet.Get<T>(key);
        // }

        /// Add bunch insertion object
        public void Add<T, TKey>(T obj, TKey key) where T : TObject {
            insertSet.Add(key, obj);
        }

    #endregion


        public void InstallTo(IDependencyContainer container) {
            foreach ((Type type, TObject value) in entries)
                container.RegisterInstance(type, value);

            // Add bunch insertions
            if (!HasInserts) return;
            foreach ((object key, object value) in insertSet) {
                container.RegisterInstance((Type) key, value);
            }
        }

    }
}