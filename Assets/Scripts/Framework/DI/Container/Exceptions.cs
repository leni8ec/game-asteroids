using System;

namespace Asteroids.Framework.DI.Container {

    public class DependencyResolveException : Exception {
        public DependencyResolveException(string message) : base(message) { }
    }

    public class DependencyRegisterException : Exception {
        public DependencyRegisterException(string message) : base(message) { }
    }

}