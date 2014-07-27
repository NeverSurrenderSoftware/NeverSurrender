using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public delegate void MouseMovementHandler(Vector2 movement);
    public delegate void MousePositionHandler(Vector2 position);

    public delegate void MouseButtonHeldHandler(List<NSMouseButtons> buttons);
    public delegate void MouseButtonPressedHandler(List<NSMouseButtons> buttons);
    public delegate void MouseButtonReleasedHandler(List<NSMouseButtons> buttons);
}
