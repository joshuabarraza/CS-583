# 🪖 Iron Shell
### 2D Arcade Tank Shooter — Unity 2D | C#

---

## Overview

Iron Shell is a top-down 2D arcade tank shooter set in wartime maze environments. Players navigate increasingly hostile battlefields — destroying supply crates, evading artillery turrets, and dueling enemy tanks — while earning Shell Credits (SC) to unlock advanced munitions.

---

## Controls

| Input | Action |
|-------|--------|
| W / A / S / D | Move tank |
| Mouse | Aim turret |
| Space | Fire |
| 1 / 2 / 3 | Swap projectile type (when unlocked) |
| Esc | Pause |

---

## Game Structure

| Level | Type | Description |
|-------|------|-------------|
| Tutorial | Training | Destroy undefended supply crates, no enemies |
| Easy (2–3) | Stationary Threats | Fixed gun turrets that fire on line-of-sight |
| Advanced (4–5) | Enemy Armor | Patrolling enemy tanks that shoot back |

---

## Progression System

Destroying enemies and crates awards **Shell Credits (SC)**. Credits unlock new projectile types between levels:

- **Standard Round** — default, fast, no ricochet
- **Ricochet Shell** (100 SC) — bounces off walls up to 2 times
- **Armor-Piercing** (200 SC) — passes through one wall or enemy
- **Homing Shell** (300 SC) — tracks nearest enemy

---

## Project Structure

```
Assets/
├── Audio/          # SFX clips (engine, shooting, impacts)
├── Scenes/         # Unity scene files
├── Scripts/
│   ├── Bullet.cs           # Projectile movement and collision
│   ├── Crate.cs            # Destructible crate logic
│   ├── GameManager.cs      # Singleton: tracks credits and health
│   ├── SoundManager.cs     # Singleton: plays positional SFX
│   ├── TankAudio.cs        # Engine and shooting audio
│   ├── TankMovement.cs     # WASD movement and turret aiming
│   ├── TankShooting.cs     # Firing logic and fire rate
│   └── UIManager.cs        # HUD: score and health bar
├── Tilemaps/       # Tile palettes and map tiles
└── Prefabs/        # Bullet prefab
```

---

## Setup

1. Clone the repo
2. Open in **Unity 2022+**
3. Open `Assets/Scenes/SampleScene`
4. Ensure **Active Input Handling** is set to `Input Manager (Old)` under Edit → Project Settings → Player
5. Hit Play

---

## Dependencies

- Unity 2D (built-in)
- TextMeshPro (imported via Unity Package Manager)
- No third-party packages required

---

## Changes from Design Document

> This file will be updated as development progresses to track any deviations from the original one-pager.

- *(none yet)*

---

## Credits

- Sound effects: [freesound.org](https://freesound.org)
- Art assets: TBD
