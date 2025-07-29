using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Asteroids.Framework.DI.Content.Bunch {
    /// <typeparam name="TKey">Always is 'object'</typeparam>
    /// <typeparam name="TObject"></typeparam>
    public class InsertSet<TKey, TObject> : IEnumerable<DictionaryEntry> {

        // note: there's no way to do it with generic 'Dictionary<,>' due to the need for implicit conversions IDictionary
        // This casting are impossible: Bundle<IConfigState, object> -> Bundle<AsteroidConfigState, AsteroidSize>
        private readonly IDictionary dict = new HybridDictionary();
        public int Count => dict.Count;

        public void Add<TK, TO>(TK key, TO obj) where TK : TKey where TO : TObject {
            Type insertType = typeof(Insert<TK, TO>);

            Insert<TK, TO> insert;
            if (dict.Contains(insertType)) {
                insert = (Insert<TK, TO>) dict[insertType];
            } else {
                insert = new Insert<TK, TO>();
                dict.Add(insertType, insert);
            }
            insert.Add(key, obj);
        }


        public IEnumerator<DictionaryEntry> GetEnumerator() {
            foreach (DictionaryEntry insert in dict) {
                yield return insert;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}