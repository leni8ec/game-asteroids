using Model.Data.State;
using Presenter.Collectors;
using Presenter.Input.Commands;

namespace Presenter.Input {

    public class InputHandler {
        private StateCollector States { get; }

        public FireCommand FireCommand { get; }
        public MoveCommand MoveCommand { get; }
        public RotateCommand RotateCommand { get; }
        public ContinueCommand ContinueCommand { get; }

        public InputHandler(StateCollector states) {
            States = states;

            FireCommand = new FireCommand(States.Get<WeaponSystemState>());
            MoveCommand = new MoveCommand(States.Get<ActiveEntitiesState>().player.State);
            RotateCommand = new RotateCommand(States.Get<ActiveEntitiesState>().player.State);
            ContinueCommand = new ContinueCommand(States.Get<GameSystemState>());
        }

    }
}