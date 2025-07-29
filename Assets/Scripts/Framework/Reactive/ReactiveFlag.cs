using System;

namespace Asteroids.Framework.Reactive {
    /// Boolean state switcher of the <see cref="ReactiveProperty{T}"/> with enable/disable triggers
    [Serializable]
    public class ReactiveFlag : ReactiveProperty<bool> {

        /// On Enable
        /// <br/><br/>
        /// when 'Value' has been changed from 'false' to 'true'
        public event Action Enabled;

        /// On Disable
        /// <br/><br/>
        /// when 'Value' has been changed from 'true' to 'false'
        public event Action Disabled;

        public bool Enable() {
            return Set(true);
        }

        public bool Disable() {
            return Set(false);
        }

        public bool Toggle() {
            return Set(!Value);
        }

        public override bool Set(bool value) {
            bool valueChanged = base.Set(value);
            if (valueChanged) {
                if (value) Enabled?.Invoke();
                else Disabled?.Invoke();
            }
            return valueChanged;
        }
    }
}