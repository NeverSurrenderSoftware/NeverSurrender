using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverSurrender.InputManagement
{

    public interface NSGamepadEventHandler
    {
        #region EVENT(S)
        event GamepadConnectionEvent OnConnection;

        event GamepadTriggerMovementEvent OnTriggerMovement;
        event GamepadTriggerPositionEvent OnTriggerPosition;
        event GamepadLeftThumbstickMovementEvent OnLeftThumbstickMovement;
        event GamepadLeftThumbstickPositionEvent OnLeftThumbstickPosition;
        event GamepadRightThumbstickMovementEvent OnRightThumbstickMovement;
        event GamepadRightThumbstickPositionEvent OnRightThumbstickPosition;

        event GamepadButtonHeldEvent OnButtonHeld;
        event GamepadButtonPressedEvent OnButtonPressed;
        event GamepadButtonReleasedEvent OnButtonReleased;

        event GamepadKeyHeldEvent OnKeyHeld;
        event GamepadKeyPressedEvent OnKeyPressed;
        event GamepadKeyReleasedEvent OnKeyReleased;
        #endregion
    }
}
