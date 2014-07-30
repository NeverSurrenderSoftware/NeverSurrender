using System;
using System.Collections.Generic;

using NSDataTypes;

namespace NeverSurrender.AssetManagement
{
    public interface NSAssetManagerService : IServiceProvider
    {
        #region METHOD(S)
        /// <summary>
        /// Attempts to add the requested asset to the Asset Manager
        /// </summary>
        /// <param name="newAsset">A Valid NSAsset object</param>
        void AddAsset(NSAsset newAsset);

        void RemoveAsset(string assetName);

        AssetType GetFirst<AssetType>() where AssetType : NSAsset;

        AssetType GetAsset<AssetType>(string assetName) where AssetType : NSAsset;

        #endregion

        #region PROPERTY(IES)
        /// <summary>
        /// Gets the dictionary of currently stored assets.
        /// </summary>
        Dictionary<string, NSAsset> Assets { get; }
        #endregion
    }
}
