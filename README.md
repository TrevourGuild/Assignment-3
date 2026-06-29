**GAME-351 – Assignment 3**

## Team Members
- Trevor Soldner Guild
- Joshua Page
- Nathan Nieto

---

# Project Description
Desert Outpost 51 / Western Town is a third-person Western action game developed in Unity. The player controls a sheriff character exploring a Western town while interacting with enemies, explosive objects, and cinematic sequences.

The game begins with an opening cutscene created using Unity's Timeline and Cinemachine systems before transitioning into gameplay.

---

# Features Implemented

## Cinematic Cutscene
- Opening cutscene created using **Unity Timeline** and **Cinemachine**.
- Uses **three virtual cameras**:
  - `VCam_OpeningTown`
  - `VCam_DollyTrack`
  - `VCam_PlayerFollow`
- Includes a **Cinemachine Dolly Track**.
- Automatic camera transitions.
- Seamless transition into gameplay.
- Cutscene can be skipped by pressing **ESC**.

---

## Player Features
- Third-person player controller.
- Character movement using WASD.
- Camera toggle system:
  - Third-person camera
  - First-person camera
- Kick attack animation.
- Gun shooting system.

---

## Combat Features
- Bandits shoot back at the player.
- Player can take damage.
- Character death system.
- Target objects react when shot.

---

## Environment Features
- Explosive barrels.
- Barrel explosion effects and sounds.
- Ambient Western environment.
- Background music and environmental audio.

---

# Controls

| Key | Action |
|------|---------|
| W | Move Forward |
| A | Move Left |
| S | Move Backward |
| D | Move Right |
| F | Fire Gun |
| Spacebar | Kick |
| T | Toggle First/Third Person Camera |
| ESC | Skip Opening Cutscene |

---

# Audio Implemented
The project includes:

- Background music
- Ambient environmental sounds
- Gunshot sound effects
- Explosion sound effects
- Character injury sounds
- Character death sounds

---

# Choice Components Implemented

✔ Cinemachine cutscene with multiple virtual cameras

✔ Dolly track camera movement

✔ Interactive combat system

✔ Enemy AI that shoots back

✔ Explosive objects

✔ First-person and third-person camera system

✔ Audio system with sound effects and music

✔ Reactive shooting targets

---

# Known Issues / Errata
- Camera transitions may require minor adjustments depending on scene modifications.
- Enemy AI may occasionally become stuck on environment objects.
- Character animations may briefly snap during rapid camera transitions.
- Additional balancing and polish could be added to enemy combat behavior.

---

# Omissions
The following features were not implemented:

- Multiplayer support
- Advanced enemy pathfinding/navigation
- Save/load system
- Inventory system

---

# Installation Instructions

## Requirements
- Unity 2021.3.5f1

## Installation Steps
1. Download or clone the repository.
2. Open **Unity Hub**.
3. Click **Open Project**.
4. Select the project folder.
5. Open the scene:

```text
Assets/Scenes/WesternTown
```

6. Press the **Play** button in Unity.

---

# Rendering Pipeline
This project uses the:

**Universal Render Pipeline (URP)**

---

# Assets Used
- Unity Cinemachine Package
- Unity Timeline Package
- Western environment assets
- Character animation assets
- Audio assets for music and sound effects

---
