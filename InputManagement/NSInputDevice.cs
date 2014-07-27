using System;

using Microsoft.Xna.Framework;

namespace NeverSurrender.InputManagement
{
    public abstract class NSInputDevice : GameComponent
    {
        #region CONSTRUCTOR(S)
        public NSInputDevice(Game game, PlayerIndex owner)
            : base(game)
        {
            Owner = owner;
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        #endregion

        #region FIELD(S)
        #endregion

        #region METHOD(S)
        #endregion

        #region PROPERTIE(S)
        public PlayerIndex Owner { get; set; }
        #endregion
    }
}
