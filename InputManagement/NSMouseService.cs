using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace NeverSurrender.InputManagement
{
    public interface NSMouseService : IServiceProvider
    {
        #region EVENT(S)
        /// <summary>
        /// An event triggered when either of the Mouse Axis positions have changed.
        /// </summary>
        event MouseMovementHandler OnMovement;
        /// <summary>
        /// An event triggered every update cycle.
        /// </summary>
        event MousePositionHandler OnPosition;

        /// <summary>
        /// An event triggered when one or more Mouse Buttons have been held down for 
        /// more than one update cycle.
        /// </summary>
        event MouseButtonHeldHandler OnButtonHeld;
        /// <summary>
        /// An event triggered when one or more Mouse Buttons have been recently pressed
        /// down.
        /// </summary>
        event MouseButtonPressedHandler OnButtonPressed;
        /// <summary>
        /// And event triggered when one or more Mouse Buttons have been recently
        /// released.
        /// </summary>
        event MouseButtonReleasedHandler OnButtonReleased;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Retrieves the handedness of the mouse device.
        /// 
        /// This default for this value is read from the users control panel registry.
        /// </summary>
        bool IsLefty { get; set; }

        /// <summary>
        /// Retrieves the amount of [calculated] movement for both Mouse axis processed 
        /// during the most recent update cycle.
        /// </summary>
        Vector2 Movement { get; }
        /// <summary>
        /// Retrieve the current Mouse Position for both axis.
        /// </summary>
        Vector2 Position { get; }

        /// <summary>
        /// Retrieves the list of Mouse Buttons that have been held for more than one 
        /// update cycle.
        /// </summary>
        List<NSMouseButtons> HeldButtons { get; }
        /// <summary>
        /// Retrieves the list of Mouse Buttons that were pressed during the previous 
        /// update cycle but are now released.
        /// </summary>
        List<NSMouseButtons> PressedButtons { get; }
        /// <summary>
        /// Retrieves the list of Mouse Buttons that are currently pressed during the 
        /// current update cycle but not for any previously.
        /// </summary>
        List<NSMouseButtons> ReleasedButtons { get; }
        #endregion
    }
}
