using System;
using System.Collections.Generic;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Game.Commands;
using Asteroids.Core.World.Players.Commands;
using Asteroids.Core.World.Players.Common;
using Asteroids.Core.World.Players.Weapons;
using Asteroids.Framework.Command;

namespace Asteroids.Application.Input {
    public class CommandsRegistry {

        private readonly Dictionary<Type, ICommand> commands = new();

        // todo-later: use in DI (as Transient, not Singleton)
        public CommandsRegistry(WeaponState weaponState, PlayersState playersState, GameState gameState) {
            Add(new FireCommand(weaponState));
            Add(new MoveCommand(playersState));
            Add(new RotateCommand(playersState));
            Add(new StartGameCommand(gameState));
        }

        public T Get<T>() where T : ICommand {
            return (T) commands[typeof(T)];
        }

        private void Add<T>(T command) where T : ICommand {
            commands.Add(typeof(T), command);
        }
    }
}