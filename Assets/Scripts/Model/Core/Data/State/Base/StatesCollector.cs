﻿namespace Model.Core.Data.State.Base {
    // todo: implement DI
    public class StatesCollector {

        public readonly EntitiesState entity = new();
        public readonly WorldSystemState world = new();

        public readonly GameSystemState game = new();
        public readonly ScoreState score = new();

        public readonly WeaponSystemState weapon = new();

    }
}