namespace Asteroids.Framework.Pool {
    public interface IPool<T> {

        int InitialCapacity { get; }

        bool IsEmpty { get; }

        /// Get existing object from the pool or create by factory method
        T Take();

        /// Return object to pool
        void Return(T element);

    }
}