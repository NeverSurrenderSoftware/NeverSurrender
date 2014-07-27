using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public delegate void KeyboardKeyHeldHandler(List<Keys> keys);
    public delegate void KeyboardKeyPressedHandler(List<Keys> keys);
    public delegate void KeyboardKeyReleasedHandler(List<Keys> keys);
}
