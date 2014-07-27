using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public delegate void GamepadConnectionEvent(bool connected);

    public delegate void GamepadTriggerMovementEvent(Vector2 movement);
    public delegate void GamepadTriggerPositionEvent(Vector2 position);
    public delegate void GamepadLeftThumbstickMovementEvent(Vector2 movement);
    public delegate void GamepadLeftThumbstickPositionEvent(Vector2 position);
    public delegate void GamepadRightThumbstickMovementEvent(Vector2 movement);
    public delegate void GamepadRightThumbstickPositionEvent(Vector2 position);

    public delegate void GamepadButtonHeldEvent(List<NSGamepadButtons> heldButtons);
    public delegate void GamepadButtonPressedEvent(List<NSGamepadButtons> heldButtons);
    public delegate void GamepadButtonReleasedEvent(List<NSGamepadButtons> heldButtons);

    public delegate void GamepadKeyHeldEvent(List<Keys> heldKeys);
    public delegate void GamepadKeyPressedEvent(List<Keys> pressedKeys);
    public delegate void GamepadKeyReleasedEvent(List<Keys> releasedKeys);
}
