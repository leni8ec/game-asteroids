using System;
using System.Collections.Generic;

namespace Asteroids.Framework.Disposables {
    /// <summary>
    /// Tracker of used resources with the possibility to dispose them
    /// </summary>
    public class DisposableTracker : IDisposable {

        private readonly List<IDisposable> disposables = new();

        public void Add(IDisposable disposable) {
            disposables.Add(disposable);
        }

        public void Dispose() {
            disposables.ForEach(e => e.Dispose());
            disposables.Clear();
        }

    }
}