using Asteroids.Framework.Reactive;
using Asteroids.Framework.Systems.Behaviour;

namespace Asteroids.Framework.Systems {
    public abstract class SystemBase : ISystem {

        public bool SystemEnabled { get; private set; }

        private bool isStarted;

        public void Initialize() {
            if (this is ICreateSystem createSystem)
                createSystem.CreateSystem();

            // Enable systems on initialization (after create)
            Enable();
        }

        /// Enable system
        /// <br/> (called after 'create', before 'start')
        /// <br/>
        /// <br/> Systems will be enabled on first initialization
        private void Enable() {
            if (SystemEnabled) return;
            SystemEnabled = true;
            OnEnableSystem();

            if (isStarted) return;
            isStarted = true;
            if (this is IStartSystem startSystem)
                startSystem.Start();
        }

        /// Disable system
        private void Disable() {
            if (!SystemEnabled) return;
            SystemEnabled = false;
            OnDisableSystem();
        }

        /// <summary>
        /// Called when the system becomes enabled
        /// <br/> (after 'create', before 'start')
        /// <br/>
        /// <br/> Systems will be enabled on first initialization
        /// </summary>
        protected virtual void OnEnableSystem() { }

        /// <summary>
        /// Called when the system becomes disabled
        /// </summary>
        protected virtual void OnDisableSystem() { }


        /// <summary>
        /// Subscribe system activity (enabled/disabled state) to a flag
        /// <br/>
        /// (enable system on 'true', disable on 'false')
        /// </summary>
        /// <param name="reactiveFlag">Bool reactive property as following flag</param>
        /// <param name="inverse">follow inversed flag value (enable system on 'false', disable on 'true')</param>
        protected void RegisterSystemActivityFlag(IReactiveProperty<bool> reactiveFlag, bool inverse = false) {
            reactiveFlag.Changed += enabled => {
                if (enabled && !inverse) Enable();
                else Disable();
            };
        }


    }
}