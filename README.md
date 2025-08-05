## Asteroids - video game

```Portfolio project```

![image](https://github.com/leni8ec/game-asteroids/assets/2379473/86ce4f7b-5b7e-4f0f-bf61-778990c0321d)

> The goal of this project is to show the possible structure of the project in
> Unity as simply as possible, <u>without any external dependencies</u>.
>
> Simple custom implementations of the:
> - dependency container
> - abstractions for factories, spawners and pools
> - elementary Reactive Properties
>
> The main focus is on <u>reducing the boilerplate code</u>.
> So it may seem that there are not enough abstractions
> (for example, the principle of Dependency Inversion is not applied everywhere),
> this is done intentionally, until those abstractions are really required
> (architecturally, they are supported)

---

### ✅ Architecture (design patterns)

- **[MVP (SC)](https://martinfowler.com/eaaDev/SupervisingPresenter.html)** - as a **Core** architectural basis (SC - supervising controller)
- **[MVP (PV)](https://martinfowler.com/eaaDev/PassiveScreen.html)** - as a **GUI** architectural basis (PV - passive view)
- **Data** (`state`, `config`) is split from **Logic** (`systems`)
- **Reactive properties** - simple realization
- **IoC, DI** - dependency injection
- **Object Pool** - spawn and reuse entities
- **Factory Method** - create new entities (used with Pool)
- **Commands (signals)** - handle input
- **Adapters** - used for Unity components (`camera`, `audio`)

### 🔲 Unity

- **Scriptable objects** (for configs)
- **Input system**

---

### ➡️ Todo

- Event System - _purpose ?_
- Save game state - repositories usage
- Unit-tests - simple usages of Unity Test Framework
---

### 🔗 Sources©️

- Graphics: https://opengameart.org/content/asteroids-vector-style-sprites
- Audio: https://www.classicgaming.cc/classics/asteroids/sounds