using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720,
                IsFullScreen = false,
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
            Content.RootDirectory = "Content";
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        #endregion

        #region FIELD(S)
        GraphicsDeviceManager deviceManager;
        #endregion

        #region METHOD(S)
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        #endregion

        #region PROPERTIE(S)
        #endregion
    }
}
