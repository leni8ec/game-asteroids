using System;

namespace Asteroids.Framework.Reactive {
    /// <summary>
    /// Integer Reactive property with an arithmetic operators overloading
    /// </summary>
    [Serializable]
    public class ReactiveInt : ReactiveProperty<int> {

        public static ReactiveInt operator ++(ReactiveInt self) {
            self.Value++;
            return self;
        }

        public static ReactiveInt operator --(ReactiveInt self) {
            self.Value--;
            return self;
        }

        public static ReactiveInt operator -(ReactiveInt self, int value) {
            self.Value -= value;
            return self;
        }

        public static ReactiveInt operator +(ReactiveInt self, int value) {
            self.Value += value;
            return self;
        }

        public static ReactiveInt operator *(ReactiveInt self, int value) {
            self.Value *= value;
            return self;
        }

        public static ReactiveInt operator /(ReactiveInt self, int value) {
            self.Value /= value;
            return self;
        }

    }

    /// <summary>
    /// Float Reactive property with an arithmetic operators overloading
    /// </summary>
    [Serializable]
    public class ReactiveFloat : ReactiveProperty<float> {
        private readonly float tolerance;


        public ReactiveFloat(float value = 0, float tolerance = 0) : base(value) {
            this.tolerance = tolerance;
        }

        // optimize float calculation with tolerance (throttling)
        // todo-tests
        public override bool Set(float value) {
            if (tolerance > 0 && MathF.Abs(value - Value) < tolerance)
                return false;
            return base.Set(value);
        }

        public static ReactiveFloat operator ++(ReactiveFloat self) {
            self.Value++;
            return self;
        }

        public static ReactiveFloat operator --(ReactiveFloat self) {
            self.Value--;
            return self;
        }

        public static ReactiveFloat operator -(ReactiveFloat self, float value) {
            self.Value -= value;
            return self;
        }

        public static ReactiveFloat operator +(ReactiveFloat self, float value) {
            self.Value += value;
            return self;
        }

        public static ReactiveFloat operator *(ReactiveFloat self, float value) {
            self.Value *= value;
            return self;
        }

        public static ReactiveFloat operator /(ReactiveFloat self, float value) {
            self.Value /= value;
            return self;
        }

    }
}