using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeverSurrender.InputManagement
{
    public sealed class NSGamepadManager : GameComponent,
        NSGamepadManagerService
    {
        #region CONSTRUCTOR(S)
        public NSGamepadManager(Game game)
            : base(game)
        {
            // Create the list of four Gamepads
            gamepads = new List<NSGamepad>(4);
            for (int i = 0; i < 4; i++)
                gamepads.Add(new NSGamepad(game, (PlayerIndex)i));

            // Register this as the NSGamepadManagerService
            Game.Services.AddService(typeof(NSGamepadManagerService), this);
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        #endregion

        #region FIELD(S)
        List<NSGamepad> gamepads;
        #endregion

        #region METHOD(S)        
        public override void Initialize()
        {
            base.Initialize();

            foreach (NSGamepad Gamepad in gamepads)
                Gamepad.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            // Iterate through each of the Gamepads and update them
            for (int i = 0; i < 4; i++)
                gamepads[i].Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Dispose(bool disposing)
        {
            foreach (NSGamepad Gamepad in gamepads)
                Gamepad.Dispose();
            gamepads.Clear();

            base.Dispose(disposing);
        }
        
        public object GetService(Type serviceType)
        {
            return this as NSGamepadManagerService;
        }

        public void RegisterEventHandler(PlayerIndex owner, GamepadConnectionEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnConnection += handler;
        }

        public void RegisterEventHandler(PlayerIndex owner, GamepadTriggerMovementEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnTriggerMovement += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadTriggerPositionEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnTriggerPosition += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadLeftThumbstickMovementEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnLeftThumbstickMovement += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadLeftThumbstickPositionEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnLeftThumbstickPosition += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadRightThumbstickMovementEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnRightThumbstickMovement += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadRightThumbstickPositionEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnRightThumbstickPosition += handler;
        }

        public void RegisterEventHandler(PlayerIndex owner, GamepadButtonHeldEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnButtonHeld += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadButtonPressedEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnButtonPressed += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadButtonReleasedEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnButtonReleased += handler;
        }

        public void RegisterEventHandler(PlayerIndex owner, GamepadKeyHeldEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnKeyHeld += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadKeyPressedEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnKeyPressed += handler;
        }
        public void RegisterEventHandler(PlayerIndex owner, GamepadKeyReleasedEvent handler)
        {
            if (null != handler)
                gamepads[(int)owner].OnKeyReleased += handler;
        }
        #endregion

        #region PROPERTY(IES)
        public List<NSGamepad> Gamepads { get { return gamepads; } }
        #endregion
    }
}
