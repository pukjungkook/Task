# Unity UI Popup Animation Test

A small Unity UI implementation focused on animated popup windows, level-complete feedback, and background blur effects.

This project was created as a technical/UI test task, demonstrating Unity UI setup, popup state control, animator-driven transitions, and a custom shader-based blur effect.

## Features

- Animated settings popup
- Level completed popup trigger
- Popup open/close animation flow
- Close button interaction
- Automatic popup disabling after close animation
- Custom UI background blur shader
- TextMesh Pro-based UI setup
- Reusable popup prefab structure

## Technical Overview

The project includes a simple popup management setup using Unity C# scripts and Animator controllers.

### Scripts

- `UIManager.cs`  
  Handles opening the settings popup and triggering its show animation.

- `PopupController.cs`  
  Handles popup close button behaviour, plays the hide animation, and disables the popup after the animation finishes.

- `LevelCompletedPopup.cs`  
  Displays a level-completed popup when the level completion state is triggered.

### Shader

- `UIBlur.shader`  
  A custom transparent UI shader using `GrabPass` to create a blurred background effect behind popup UI elements.

## Project Structure

```text
Assets/
├── Animations/
├── Fonts/
├── Scenes/
├── Scripts/
│   ├── LevelCompletedPopup.cs
│   ├── PopupController.cs
│   └── UIManager.cs
├── TextMesh Pro/
├── UI/
├── BasePopup.prefab
├── UIBlur.shader
└── UIBlurMat.mat
