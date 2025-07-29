using System.Collections;
using System.Collections.Generic;

namespace Asteroids.Framework.DI.Content.Bunch {
    /// <inheritdoc cref="IBunch"/>
    public class Bunch<TKey, TObject> : IBunch, IEnumerable<KeyValuePair<TKey, TObject>> {

        private readonly IDictionary<TKey, TObject> contents = new Dictionary<TKey, TObject>();

        public TObject this[TKey key] => Get(key);

        public TObject Get(TKey key) {
            return contents[key];
        }

        internal void Add(TKey key, object obj) {
            contents.Add(key, (TObject) obj);
        }


        public IEnumerator<KeyValuePair<TKey, TObject>> GetEnumerator() {
            return contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}