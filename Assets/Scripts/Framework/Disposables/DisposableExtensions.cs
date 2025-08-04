using System;

namespace Asteroids.Framework.Disposables {

    public static class DisposableExtensions {

        /// Add disposable to the disposable tracker.
        public static T AddTo<T>(this T disposable, DisposableTracker tracker) where T : IDisposable {
            tracker?.Add(disposable);
            return disposable;
        }

    }
}