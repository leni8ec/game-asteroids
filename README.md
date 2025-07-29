## Asteroids - video game
```Portfolio project```

![image](https://github.com/leni8ec/game-asteroids/assets/2379473/86ce4f7b-5b7e-4f0f-bf61-778990c0321d)

> The goal of this project is to show the possible structure of the project in 
> Unity as simply as possible, without any external dependencies.
> 
> Simple custom implementations of the:
> - dependency container
> - abstractions for factories, spawners and pools
> - elementary Reactive Properties

---

### ✅ Architecture (design patterns)
- **MV\* (SC)** - base architecture pattern (SC - supervising controller)
- **Data** (`state`, `config`) is split from **Logic** (`systems`)
- **Reactive properties** - simple realization
- **IoC, DI** - dependency injection 
- **Object Pool** - spawn and reuse entities
- **Factory Method** - create new entities (used with Pool)
- **Command pattern** - handle input
- **Adapter pattern** - view (unity objects) implementation for some model objects (`camera`, `audio`)


### 🔲 Unity
- **Scriptable objects** (for config)
- **Input system**

---

### ➡️ Todo
- Event System - purpose?
- UnityView - need to refactoring
- Code cleanup (add docs)

---

### 🔗 Sources©️
- Graphics: https://opengameart.org/content/asteroids-vector-style-sprites
- Audio: https://www.classicgaming.cc/classics/asteroids/sounds