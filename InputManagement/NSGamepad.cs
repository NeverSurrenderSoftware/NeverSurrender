using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public sealed class NSGamepad : NSInputDevice
    {
        #region CONSTRUCTOR(S)
        public NSGamepad(Game game, PlayerIndex owner)
            : base(game, owner)
        {

        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        public event GamepadConnectionEvent OnConnection;

        public event GamepadTriggerMovementEvent OnTriggerMovement;
        public event GamepadTriggerPositionEvent OnTriggerPosition;
        public event GamepadLeftThumbstickMovementEvent OnLeftThumbstickMovement;
        public event GamepadLeftThumbstickPositionEvent OnLeftThumbstickPosition;
        public event GamepadRightThumbstickMovementEvent OnRightThumbstickMovement;
        public event GamepadRightThumbstickPositionEvent OnRightThumbstickPosition;

        public event GamepadButtonHeldEvent OnButtonHeld;
        public event GamepadButtonPressedEvent OnButtonPressed;
        public event GamepadButtonReleasedEvent OnButtonReleased;

        public event GamepadKeyHeldEvent OnKeyHeld;
        public event GamepadKeyPressedEvent OnKeyPressed;
        public event GamepadKeyReleasedEvent OnKeyReleased;
        #endregion

        #region FIELD(S)
        int packet;

        Vector2 triggerMovement;
        Vector2 triggerPosition;
        Vector2 leftStickMovement;
        Vector2 leftStickPosition;
        Vector2 rightStickMovement;
        Vector2 rightStickPosition;

        bool connected;

        bool[] currentButtons;
        bool[] previousButtons;

        GamePadState currentState;

        List<NSGamepadButtons> heldButtons;
        List<NSGamepadButtons> pressedButtons;
        List<NSGamepadButtons> releasedButtons;
        #endregion

        #region METHOD(S)
        public override void Initialize()
        {
            base.Initialize();

            connected = true;

            currentState = GamePad.GetState(Owner);

            currentButtons = new bool[24];
            previousButtons = new bool[24];

            for (int i = 0; i < 24; i++)
            {
                currentButtons[i] = false;
                previousButtons[i] = false;
            }

            triggerMovement = Vector2.Zero;
            triggerPosition = Vector2.Zero;
            leftStickMovement = Vector2.Zero;
            leftStickPosition = Vector2.Zero;
            rightStickMovement = Vector2.Zero;
            rightStickPosition = Vector2.Zero;

            heldButtons = new List<NSGamepadButtons>();
            pressedButtons = new List<NSGamepadButtons>();
            releasedButtons = new List<NSGamepadButtons>();

            GetCurrentState();
        }
        public override void Update(GameTime gameTime)
        {
            #region GAMEPAD BUTTON STATE PROCESSING
            // Get the current gamepad state
            GetCurrentState();

            // Clear the button action lists and prepare them for reuse
            heldButtons.Clear();
            pressedButtons.Clear();
            releasedButtons.Clear();

            // Iterate through each of the button states and process them.
            for (int i = 0; i < 24; i++)
            {
                if (currentButtons[i] && !previousButtons[i]) pressedButtons.Add((NSGamepadButtons)i);
                else if (currentButtons[i] && previousButtons[i]) heldButtons.Add((NSGamepadButtons)i);
                else if (!currentButtons[i] && previousButtons[i]) releasedButtons.Add((NSGamepadButtons)i);
            }
            #endregion

            #region GAMEPAD AXIS STATE PROCESSING
            triggerMovement.X = triggerPosition.X - currentState.Triggers.Left;
            triggerMovement.Y = triggerPosition.Y - currentState.Triggers.Right;
            triggerPosition.X = currentState.Triggers.Left;
            triggerPosition.Y = currentState.Triggers.Right;

            leftStickMovement = leftStickPosition - currentState.ThumbSticks.Left;
            leftStickPosition = currentState.ThumbSticks.Left;

            rightStickMovement = rightStickPosition - currentState.ThumbSticks.Right;
            rightStickPosition = currentState.ThumbSticks.Right;
            #endregion

            #region KEYPAD STATE PROCESSING
            #endregion

            #region EVENT HANDLING
            if (null != OnButtonHeld && heldButtons.Count > 0) OnButtonHeld(heldButtons);
            if (null != OnButtonPressed && pressedButtons.Count > 0) OnButtonPressed(pressedButtons);
            if (null != OnButtonReleased && releasedButtons.Count > 0) OnButtonReleased(releasedButtons);

            if (null != OnTriggerPosition) OnTriggerPosition(triggerPosition);
            if (null != OnLeftThumbstickPosition) OnLeftThumbstickPosition(leftStickPosition);
            if (null != OnRightThumbstickPosition) OnRightThumbstickPosition(rightStickPosition);
            if (null != OnTriggerMovement && triggerMovement.Length() != 0) OnTriggerMovement(triggerMovement);
            if (null != OnLeftThumbstickMovement && leftStickMovement.Length() != 0) OnLeftThumbstickMovement(leftStickMovement);
            if (null != OnRightThumbstickMovement && rightStickMovement.Length() != 0) OnRightThumbstickMovement(rightStickMovement);
            #endregion

            base.Update(gameTime);
        }

        private void GetCurrentState()
        {
            // Store the previous button states
            for (int i = 0; i < 24; i++)
                previousButtons[i] = currentButtons[i];

            // Retrieve the current gamepad state
            currentState = GamePad.GetState(Owner);

            // If nothing has changed then there is no reason to reprocess the button 
            // or axis states.
            if (packet != currentState.PacketNumber)
            {
                currentButtons[00] = currentState.IsButtonDown(Buttons.A);
                currentButtons[01] = currentState.IsButtonDown(Buttons.B);
                currentButtons[02] = currentState.IsButtonDown(Buttons.X);
                currentButtons[03] = currentState.IsButtonDown(Buttons.Y);

                currentButtons[04] = currentState.IsButtonDown(Buttons.Back);
                currentButtons[05] = currentState.IsButtonDown(Buttons.Start);

                currentButtons[06] = currentState.IsButtonDown(Buttons.DPadUp);
                currentButtons[07] = currentState.IsButtonDown(Buttons.DPadDown);
                currentButtons[08] = currentState.IsButtonDown(Buttons.DPadLeft);
                currentButtons[09] = currentState.IsButtonDown(Buttons.DPadRight);

                currentButtons[10] = currentState.IsButtonDown(Buttons.LeftShoulder);
                currentButtons[11] = currentState.IsButtonDown(Buttons.RightShoulder);

                currentButtons[12] = currentState.IsButtonDown(Buttons.LeftTrigger);
                currentButtons[13] = currentState.IsButtonDown(Buttons.RightTrigger);

                currentButtons[14] = currentState.IsButtonDown(Buttons.LeftStick);
                currentButtons[15] = currentState.IsButtonDown(Buttons.LeftThumbstickUp);
                currentButtons[16] = currentState.IsButtonDown(Buttons.LeftThumbstickDown);
                currentButtons[17] = currentState.IsButtonDown(Buttons.LeftThumbstickLeft);
                currentButtons[18] = currentState.IsButtonDown(Buttons.LeftThumbstickRight);

                currentButtons[19] = currentState.IsButtonDown(Buttons.RightStick);
                currentButtons[20] = currentState.IsButtonDown(Buttons.RightThumbstickUp);
                currentButtons[21] = currentState.IsButtonDown(Buttons.RightThumbstickDown);
                currentButtons[22] = currentState.IsButtonDown(Buttons.RightThumbstickLeft);
                currentButtons[23] = currentState.IsButtonDown(Buttons.RightThumbstickRight);

                // Store the packet number to avoid reprocessing Gamepad states
                packet = currentState.PacketNumber;
            }
        }
        #endregion

        #region PROPERTY(IES)
        public bool Connected { get { return connected; } }

        public Vector2 TriggerMovement { get { return triggerMovement; } }
        public Vector2 TriggerPosition { get { return triggerPosition; } }
        public Vector2 LeftThumbstickMovement { get { return leftStickMovement; } }
        public Vector2 LeftThumbstickPosition { get { return leftStickPosition; } }
        public Vector2 RightThumbstickMovement { get { return rightStickMovement; } }
        public Vector2 RightThumbstickPosition { get { return rightStickPosition; } }

        public List<NSGamepadButtons> HeldButtons { get { return heldButtons; } }
        public List<NSGamepadButtons> PressedButtons { get { return pressedButtons; } }
        public List<NSGamepadButtons> ReleasedButtons { get { return releasedButtons; } }
        #endregion
    }
}
