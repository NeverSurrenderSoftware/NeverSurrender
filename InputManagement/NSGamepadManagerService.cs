using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace NeverSurrender.InputManagement
{
    public interface NSGamepadManagerService : IServiceProvider
    {
        #region METHOD(S)
        /// <summary>
        /// Registers the GamepadConnectionEvent handler to the OnConnection event of the 
        /// requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadConnectionEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadConnectionEvent handler);

        /// <summary>
        /// Registers the GamepadAxisMovementEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadAxisMovementEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadTriggerMovementEvent handler);
        /// <summary>
        /// Registers the GamepadAxisPositionEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadAxisPositionEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadTriggerPositionEvent handler);
        /// <summary>
        /// Registers the GamepadAxisMovementEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadAxisMovementEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadLeftThumbstickMovementEvent handler);
        /// <summary>
        /// Registers the GamepadAxisPositionEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadAxisPositionEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadLeftThumbstickPositionEvent handler);
        /// <summary>
        /// Registers the GamepadAxisMovementEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadAxisMovementEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadRightThumbstickMovementEvent handler);
        /// <summary>
        /// Registers the GamepadAxisPositionEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadAxisPositionEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadRightThumbstickPositionEvent handler);

        /// <summary>
        /// Registers the GamepadButtonHeldEvent handler to the OnConnection event of the 
        /// requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadButtonHeldEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadButtonHeldEvent handler);
        /// <summary>
        /// Registers the GamepadButtonPressedEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadButtonPressedEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadButtonPressedEvent handler);
        /// <summary>
        /// Registers the GamepadButtonReleasedEvent handler to the OnConnection event of 
        /// the requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadButtonReleasedEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadButtonReleasedEvent handler);

        /// <summary>
        /// Registers the GamepadKeyHeldEvent handler to the OnConnection event of the 
        /// requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadKeyHeldEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadKeyHeldEvent handler);
        /// <summary>
        /// Registers the GamepadKeyPressedEvent handler to the OnConnection event of the 
        /// requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">Valid GamepadKeyPressedEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadKeyPressedEvent handler);
        /// <summary>
        /// Registers the GamepadKeyReleasedEvent handler to the OnConnection event of the 
        /// requested owners Gamepad.
        /// </summary>
        /// <param name="owner">Valid PlayerIndex</param>
        /// <param name="handler">ValidGamepadKeyReleasedEvent delegate</param>
        void RegisterEventHandler(PlayerIndex owner, GamepadKeyReleasedEvent handler);
        #endregion

        #region PROPERTY(IES)
        /// <summary>
        /// Gets the list of all NSGamePads. This allows components to have direct access 
        /// to each of the players' input devices should it ever be necessary.
        /// </summary>
        List<NSGamepad> Gamepads { get; }
        #endregion
    }
}
