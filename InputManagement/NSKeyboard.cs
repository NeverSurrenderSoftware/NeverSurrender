using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public sealed class NSKeyboard : NSInputDevice,
        NSKeyboardService
    {
        #region CONSTRUCTOR(S)
        public NSKeyboard(Game game, PlayerIndex owner = PlayerIndex.One)
            : base(game, owner)
        {
            // Register this as the KeyboardService so that other GameComponents may 
            // access the actions
            Game.Services.AddService(typeof(NSKeyboardService), this);
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        public event KeyboardKeyHeldHandler OnKeyHeld;
        public event KeyboardKeyPressedHandler OnKeyPressed;
        public event KeyboardKeyReleasedHandler OnKeyReleased;
        #endregion

        #region FIELD(S)
        KeyboardState currentState;
        KeyboardState previousState;

        List<Keys> heldKeys;
        List<Keys> pressedKeys;
        List<Keys> releasedKeys;
        #endregion

        #region METHOD(S)
        public object GetService(Type serviceType)
        {
            return this as NSKeyboardService;
        }

        public void RegisterEventHandler(KeyboardKeyHeldHandler handler)
        {
            if (null != handler) OnKeyHeld += handler;
        }
        public void RegisterEventHandler(KeyboardKeyPressedHandler handler)
        {
            if (null != handler) OnKeyPressed += handler;
        }
        public void RegisterEventHandler(KeyboardKeyReleasedHandler handler)
        {
            if (null != handler) OnKeyReleased += handler;
        }

        public void UnegisterEventHandler(KeyboardKeyHeldHandler handler)
        {
            if (null != handler) OnKeyHeld -= handler;
        }
        public void UnegisterEventHandler(KeyboardKeyPressedHandler handler)
        {
            if (null != handler) OnKeyPressed -= handler;
        }
        public void UnegisterEventHandler(KeyboardKeyReleasedHandler handler)
        {
            if (null != handler) OnKeyReleased -= handler;
        }

        public override void Initialize()
        {
            base.Initialize();

            currentState = Keyboard.GetState();
            previousState = Keyboard.GetState();

            heldKeys = new List<Keys>();
            pressedKeys = new List<Keys>();
            releasedKeys = new List<Keys>();
        }
        public override void Update(GameTime gameTime)
        {
            #region KEYBOARD STATE PROCESSING
            // Store the previous KeyboardState and retrieve the current KeyboardState
            previousState = currentState;
            currentState = Keyboard.GetState();

            // Prepare the action lists for use
            heldKeys.Clear();
            pressedKeys.Clear();
            releasedKeys.Clear();

            // Retrieve the currently pressed keys and process them for Pressed and Held 
            // key states.
            Keys[] Keys = currentState.GetPressedKeys();
            foreach (Keys Key in Keys)
            {
                if (previousState.IsKeyUp(Key)) pressedKeys.Add(Key);
                else heldKeys.Add(Key);
            }

            // Retrieve the previously pressed keys and process them for Released key
            // states.
            Keys = previousState.GetPressedKeys();
            foreach (Keys Key in Keys)
            {
                if (currentState.IsKeyUp(Key)) ReleasedKeys.Add(Key);
            }
            #endregion

            #region EVENT HANDLING
            if (null != OnKeyHeld && heldKeys.Count > 0) OnKeyHeld(heldKeys);
            if (null != OnKeyPressed && pressedKeys.Count > 0) OnKeyPressed(pressedKeys);
            if (null != OnKeyReleased && releasedKeys.Count > 0) OnKeyReleased(releasedKeys);
            #endregion

            base.Update(gameTime);
        }
        #endregion

        #region PROPERTY(IES)
        public List<Keys> HeldKeys { get { return heldKeys; } }
        public List<Keys> PressedKeys { get { return pressedKeys; } }
        public List<Keys> ReleasedKeys { get { return releasedKeys; } }
        #endregion
    }
}
