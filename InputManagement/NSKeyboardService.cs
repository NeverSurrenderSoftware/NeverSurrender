using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace NeverSurrender.InputManagement
{
    public interface NSKeyboardService : IServiceProvider
    {
        #region EVENT(S)
        /// <summary>
        /// An event triggered when one or more Keyboard Keys have been held down for one 
        /// or more update cycles.
        /// </summary>
        event KeyboardKeyHeldHandler OnKeyHeld;
        /// <summary>
        /// An event triggered when one or more Keyboard Keys have been recently pressed 
        /// down.
        /// </summary>
        event KeyboardKeyPressedHandler OnKeyPressed;
        /// <summary>
        /// And event triggered when one or more keyboard keys have been recently 
        /// released.
        /// </summary>
        event KeyboardKeyReleasedHandler OnKeyReleased;
        #endregion

        #region METHOD(S)
        void RegisterEventHandler(KeyboardKeyHeldHandler handler);
        void RegisterEventHandler(KeyboardKeyPressedHandler handler);
        void RegisterEventHandler(KeyboardKeyReleasedHandler handler);

        void UnegisterEventHandler(KeyboardKeyHeldHandler handler);
        void UnegisterEventHandler(KeyboardKeyPressedHandler handler);
        void UnegisterEventHandler(KeyboardKeyReleasedHandler handler);
        #endregion

        #region PROPERTY(IES)
        /// <summary>
        /// Retrieves a list of all Keys that have been held down for more than one 
        /// update cycle.
        /// </summary>
        List<Keys> HeldKeys { get; }
        /// <summary>
        /// Retrieves a list of all Keys that were pressed down for the most recent 
        /// update cycle but none before it.
        /// </summary>
        List<Keys> PressedKeys { get; }
        /// <summary>
        /// Retrieves a list of all Keys that were pressed down during the previous 
        /// update cycle but not the current one.
        /// </summary>
        List<Keys> ReleasedKeys { get; }
        #endregion
    }
}
