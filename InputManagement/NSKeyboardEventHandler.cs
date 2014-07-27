using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverSurrender.InputManagement
{
    public interface NSKeyboardEventHandler
    {
        #region EVENT(S)
        event KeyboardKeyHeldHandler OnKeyHeld;
        event KeyboardKeyPressedHandler OnKeyPressed;
        event KeyboardKeyReleasedHandler OnKeyReleased;
        #endregion
    }
}
