namespace Asteroids.Core.World.Common.Values {

    // todo-naming: 'LevelStatus' ?
    // todo-consider: move to Game domain (see also: 'GameState')
    public enum GameStatus {
        Initialization,
        Play,
        Pause,
        End
    }

}