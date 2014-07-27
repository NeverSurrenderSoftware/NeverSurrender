using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using NeverSurrender.InputManagement;

namespace NeverSurrender
{
    public sealed class NSGame : Game
    {
        #region CONSTRUCTOR(S)
        public NSGame()
        {
            // Create the GraphicsDeviceManager applying the generalized settings for 
            // DEBUG or NORMAL modes.
#if DEBUG
            deviceManager = new GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = false,
                PreferredBackBufferWidth = 1920,
                PreferredBackBufferHeight = 1080,
                IsFullScreen = true,
            };

            IsMouseVisible = true;
            IsFixedTimeStep = false;
#else
            deviceManager = new GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = true,
                PreferredBackBufferWidth = 1920,
                PreferredBackBufferHeight = 1080,
                IsFullScreen = true,
            };

            IsMouseVisible = false;
            IsFixedTimeStep = true;
#endif

            // Set the default Content location
            Content.RootDirectory = "Data";

            // Create the Gamepad Manager, apply any local event listeners, and add it 
            // to the Components list.
            gamepadManager = new NSGamepadManager(this);
            Components.Add(gamepadManager);

            OnGamepadButtonHeld += EscapeRoute;
            gamepadManager.RegisterEventHandler(PlayerIndex.One, OnGamepadButtonHeld);

#if WINDOWS || DEBUG
            // Create the Keyboard Device, apply any local event listeners, and add it to
            // the Components list
            keyboard = new NSKeyboard(this);
            OnKeyPressed += EscapeRoute;
            keyboard.RegisterEventHandler(OnKeyPressed);

            Components.Add(keyboard);

            // Create the Mouse Device, apply any local event listeners, and add it to 
            // the Components list.
            mouse = new NSMouse(this);
            Components.Add(mouse);
#endif 
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        KeyboardKeyPressedHandler OnKeyPressed;
        GamepadButtonHeldEvent OnGamepadButtonHeld;
        #endregion

        #region FIELD(S)
        NSGamepadManager gamepadManager;
        GraphicsDeviceManager deviceManager;

#if WINDOWS || DEBUG
        NSMouse mouse;
        NSKeyboard keyboard;
#endif
        #endregion

        #region METHOD(S)
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>(@"System\Fonts\normal");
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

#if DEBUG
            spriteBatch.Begin();

            spriteBatch.End();
#endif
            base.Draw(gameTime);
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// A hard-coded escape route available while the game is being run in DEBUG mode.
        /// </summary>
        /// <param name="pressedKeys"></param>
        private void EscapeRoute(List<Keys> pressedKeys)
        {
#if DEBUG
            if (pressedKeys.Contains(Keys.Escape)) Exit();
#endif
        }
        private void EscapeRoute(List<NSGamepadButtons> heldButtons)
        {
            if (heldButtons.Contains(NSGamepadButtons.BACK) && heldButtons.Contains(NSGamepadButtons.A))
                Exit();
        }
        #endregion

        #region PROPERTY(IES)
        #endregion

        #region TESTBED
        SpriteFont spriteFont;
        SpriteBatch spriteBatch;
        #endregion
    }
}
