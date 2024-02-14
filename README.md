## Asteroids - video game
> _Portfolio project_

![image](https://github.com/leni8ec/game-asteroids/assets/2379473/86ce4f7b-5b7e-4f0f-bf61-778990c0321d)


---

### ✅ Architecture used
- **MVC** - base architecture pattern (also to be able to Client/Server case?)
- **Factory Method** - create new entities (use in Pool)
- **Object Pool** - spawn and reuse entities
- **Command pattern** - input
- **Adapter pattern** - view implementations for some model objects (`camera`, `audio`)
- The **Data** (`state`, `config`) is split from **Logic** (`systems`)

### 🔲 Unity
- **Scriptable objects** (for config)
- **Input system**

---

### ➡️ Todo
- Implement **Dependency Injection** (DI, IoC)
