using System;
using System.Collections.Generic;

using Microsoft.Win32;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public sealed class NSMouse : NSInputDevice,
        NSMouseService
    {
        #region CONSTRUCTOR(S)
        public NSMouse(Game game, PlayerIndex owner = PlayerIndex.One)
            : base(game, owner)
        {
            // Register this as the NSMouseService
            Game.Services.AddService(typeof(NSMouseService), this);
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        public event MouseMovementHandler OnMovement;
        public event MousePositionHandler OnPosition;

        public event MouseButtonHeldHandler OnButtonHeld;
        public event MouseButtonPressedHandler OnButtonPressed;
        public event MouseButtonReleasedHandler OnButtonReleased;
        #endregion

        #region FIELD(S)
        Vector2 position;
        Vector2 movement;

        MouseState currentState;

        bool[] currentButtons;
        bool[] previousButtons;

        List<NSMouseButtons> heldButtons;
        List<NSMouseButtons> pressedButtons;
        List<NSMouseButtons> releasedButtons;
        #endregion

        #region METHOD(S)
        public object GetService(Type serviceType)
        {
            return this as NSMouseService;
        }

        public void RegisterEventHandler(MouseMovementHandler handler)
        {
            if (null != handler) OnMovement += handler;
        }
        public void RegisterEventHandler(MousePositionHandler handler)
        {
            if (null != handler) OnPosition += handler;
        }

        public void RegisterEventHandler(MouseButtonHeldHandler handler)
        {
            if (null != handler) OnButtonHeld += handler;
        }
        public void RegisterEventHandler(MouseButtonPressedHandler handler)
        {
            if (null != handler) OnButtonPressed += handler;
        }
        public void RegisterEventHandler(MouseButtonReleasedHandler handler)
        {
            if (null != handler) OnButtonReleased += handler;
        }

        public void UnregisterEventHandler(MouseMovementHandler handler)
        {
            if (null != handler) OnMovement -= handler;
        }
        public void UnregisterEventHandler(MousePositionHandler handler)
        {
            if (null != handler) OnPosition -= handler;
        }

        public void UnregisterEventHandler(MouseButtonHeldHandler handler)
        {
            if (null != handler) OnButtonHeld -= handler;
        }
        public void UnregisterEventHandler(MouseButtonPressedHandler handler)
        {
            if (null != handler) OnButtonPressed -= handler;
        }
        public void UnregisterEventHandler(MouseButtonReleasedHandler handler)
        {
            if (null != handler) OnButtonReleased -= handler;
        }

        public override void Initialize()
        {
            base.Initialize();

            currentState = Mouse.GetState();

            movement = Vector2.Zero;
            position = new Vector2(currentState.X, currentState.Y);

            heldButtons = new List<NSMouseButtons>();
            pressedButtons = new List<NSMouseButtons>();
            releasedButtons = new List<NSMouseButtons>();

            currentButtons = new bool[] { false, false, false, false, false };
            previousButtons = new bool[] { false, false, false, false, false };

            string Value = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SwapMouseButtons", null);
            IsLefty = Value == "0" ? false : true;
        }
        public override void Update(GameTime gameTime)
        {
            #region CURRENT STATE PROCESSING
            // Retrieve the current MouseButton states
            GetCurrentState();

            // Clear the Action Lists and prepare them for use
            heldButtons.Clear();
            pressedButtons.Clear();
            releasedButtons.Clear();

            // Process MouseButton Actions
            for (int i = 0; i < 5; i++)
            {
                if (currentButtons[i])
                {
                    if (!previousButtons[i]) pressedButtons.Add((NSMouseButtons)i);
                    else heldButtons.Add((NSMouseButtons)i);
                }
                if (previousButtons[i])
                {
                    if (!currentButtons[i]) releasedButtons.Add((NSMouseButtons)i);
                }
            }

            // Process MouseAxis Actions
            movement.X = position.X - currentState.X;
            movement.Y = position.Y - currentState.Y;

            position.X = currentState.X;
            position.Y = currentState.Y;
            #endregion

            #region EVENT PROCESSING
            if (null != OnPosition) OnPosition(position);
            if (null != OnMovement && movement.Length() != 0) OnMovement(movement);

            if (null != OnButtonHeld && heldButtons.Count > 0) OnButtonHeld(heldButtons);
            if (null != OnButtonPressed && pressedButtons.Count > 0) OnButtonPressed(pressedButtons);
            if (null != OnButtonReleased && releasedButtons.Count > 0) OnButtonReleased(releasedButtons);
            #endregion

            base.Update(gameTime);
        }

        private void GetCurrentState()
        {
            // Retrieve the current MouseState
            currentState = Mouse.GetState();

            // Store the previous button states
            for (int i = 0; i < 5; i++)
                previousButtons[i] = currentButtons[i];

            // Store the current Mouse Button states
            currentButtons[0] = IsLefty ? currentState.RightButton == ButtonState.Pressed ? true : false : 
                currentState.LeftButton == ButtonState.Pressed ? true : false;
            currentButtons[1] = IsLefty ? currentState.LeftButton == ButtonState.Pressed ? true : false :
                currentState.RightButton == ButtonState.Pressed ? true : false;
            currentButtons[2] = currentState.MiddleButton == ButtonState.Pressed ? true : false;
            currentButtons[3] = currentState.XButton1 == ButtonState.Pressed ? true : false;
            currentButtons[4] = currentState.XButton2 == ButtonState.Pressed ? true : false;
        }
        #endregion

        #region PROPERTY(IES)
        public bool IsLefty { get; set; }

        public Vector2 Movement { get { return movement; } }
        public Vector2 Position { get { return position; } }

        public List<NSMouseButtons> HeldButtons { get { return heldButtons; } }
        public List<NSMouseButtons> PressedButtons { get { return pressedButtons; } }
        public List<NSMouseButtons> ReleasedButtons { get { return releasedButtons; } }
        #endregion
    }
}
