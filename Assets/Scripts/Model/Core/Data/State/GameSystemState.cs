﻿using Model.Core.Data.State.Base;
using Model.Core.Game;
using Model.Core.Interface.State;

namespace Model.Core.Data.State {
    public class GameSystemState : IStateData {

        public ValueChange<bool> ContinueFlag { get; } = new();
        public ValueChange<GameStatus> Status { get; } = new();


        public void Reset() {
            ContinueFlag.Reset();
            Status.Reset();
        }

    }
}