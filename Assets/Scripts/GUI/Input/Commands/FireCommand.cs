using Asteroids.Core.World.Weapon;
using Asteroids.Framework.Command;

namespace Asteroids.GUI.Input.Commands {
    public class FireCommand : CommandBase<WeaponState> {

        public FireCommand(WeaponState state) : base(state) { }

        public void Execute(bool activeFlag, int weaponNumber) {
            Weapon weapon = weaponNumber == 1
                ? Weapon.Gun
                : Weapon.Laser;

            if (activeFlag) {
                State.ActiveWeapons |= weapon;
            } else {
                State.ActiveWeapons &= ~weapon;
            }
        }

    }
}