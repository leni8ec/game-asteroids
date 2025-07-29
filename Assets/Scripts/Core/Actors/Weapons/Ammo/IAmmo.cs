using Asteroids.Framework.Entity;

namespace Asteroids.Core.Actors.Weapons.Ammo {
    // todo-consider: renaming
    // Ammo - означает не сами "снаряды" для оружия, а наличие их в плане боеприпасов в запасе.
    // т.е. возможно это не очень подходит для уже выпущенных "снарядов", которые обрабатываются на карте
    public interface IAmmo : IEntity {

        /// Firing the weapon's ammunition
        void Emit();

    }
}