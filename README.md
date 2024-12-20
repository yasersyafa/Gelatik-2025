# Unity Project GELATIK 2025 - Validashiet

Welcome to the Unity project repository! 🎮 This document provides guidelines for contributing, cloning, and working with this project.

---

## 🚀 How to Clone the Repository
1. Open your terminal or command prompt.
2. Run the following command:
   ```bash
   git clone https://github.com/yasersyafa/Gelatik-2025.git
   ```
3. Navigate to the project directory:
   ```bash
   cd Gelatik-2025
   ```

---

## 🛠️ Branch Naming Convention
When creating a new branch, please follow this naming convention:
- **scene/scene_name**
- **feature/feature_name**
- Example:
  ```bash
  scene/main-menu
  ```

---

## 📂 Folder Structure
The project is organized into the following folder structure:

```
📂 Assets
 ┣ 📂 MinigameName
 ┃ ┣ 📂 UI
 ┃ ┣ 📂 Characters
 ┃ ┣ 📂 Environment
 ┃ ┣ 📂 Audio
 ┃ ┣ 📂 Animations
 ┃ ┣ 📂 Prefabs
 ┃ ┗ 📂 Scripts
 ┣ 📂 MinigameName
 ┃ ┣ 📂 UI
 ┃ ┣ 📂 Characters
 ┃ ┣ 📂 Environment
 ┃ ┣ 📂 Audio
 ┃ ┣ 📂 Animations
 ┃ ┣ 📂 Prefabs
 ┃ ┗ 📂 Scripts
```

- **Scenes**
  - Contains the Unity scenes.
- **UI**
  - All UI-related assets.
- **Characters**
  - Character in scene assets.
- **Environment**
  - World building scene assets.
- **Audio**
  - Audio files such as sound effects and music.
- **Scripts**
  - C# scripts for the project.
- **Prefabs**
  - Prefabricated objects.
- **Animations**
  - Animation files.

Please ensure that you maintain this structure when adding new files.

---

## ⚠️ Important Rules

- **Scene naming convention**: Use the format `Minigames{name}`

### 🔒 No Direct Merging
All merges must be done via a **Pull Request (PR)**. This ensures proper code review and avoids unintended changes.

### ❌ Do Not Use Others' Branches
Do not work on someone else’s branch without their explicit permission. Always respect the ownership of branches.

---

## 🧩 Design Patterns Used
This project utilizes the following design patterns to ensure scalability and maintainability:

- **State Pattern**: For managing object states.
- **Observer Pattern**: For handling event-driven communication.
- **Decorator Pattern**: For extending functionality dynamically.

---

Thank you for contributing and maintaining the quality of this project! 🌟

