using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using NSDataTypes;

namespace NeverSurrender.AssetManagement
{
    public sealed class NSAssetManager : GameComponent,
        NSAssetManagerService
    {
        #region CONSTRUCTOR(S)
        public NSAssetManager(Game game, string rootDirectory = "Data")
            : base(game)
        {
            Root = rootDirectory;
        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        public event AssetLoaded OnAssetLoaded;
        public event AssetUnloaded OnAssetUnloaded;
        #endregion

        #region FIELD(S)
        private ContentManager content;
        private Dictionary<string, NSAsset> assetDictionary;
        #endregion

        #region METHOD(S)
        public object GetService(Type serviceType)
        {
            return this as NSAssetManagerService;
        }

        public void AddAsset(NSAsset newAsset)
        {
            if (null != newAsset)
            {
                if (!assetDictionary.ContainsKey(newAsset.Name))
                {
                    assetDictionary.Add(newAsset.Name, newAsset);
                    LoadingComplete = false;
                }
            }
        }
        public void RemoveAsset(string assetName)
        {
            if (assetDictionary.ContainsKey(assetName))
                assetDictionary.Remove(assetName);
        }
        public void LoadDataFile(string filePath)
        {
            content.Unload();
            assetDictionary.Clear();

            NSAsset[] Data = content.Load<NSAsset[]>(filePath);
            foreach (NSAsset Asset in Data)
                AddAsset(Asset);
        }
        public AssetType GetFirst<AssetType>() where AssetType : NSAsset
        {
            foreach (NSAsset Asset in assetDictionary.Values)
            {
                if (Asset is AssetType)
                    return Asset as AssetType;
            }

            throw new Exception("The AssetManager failed to return an asset of the requested type (" + typeof(AssetType).Name + ")");
        }
        public AssetType GetAsset<AssetType>(string assetName) where AssetType : NSAsset
        {
            if (assetDictionary.ContainsKey(assetName))
                if (assetDictionary[assetName] is AssetType)
                    return assetDictionary[assetName] as AssetType;

            return GetFirst<AssetType>();
        }


        public override void Initialize()
        {
            base.Initialize();

            // Create the AssetDictionary
            assetDictionary = new Dictionary<string, NSAsset>();

            // Create the ContentManager
            content = new ContentManager(Game.Services);
            content.RootDirectory = Root;

            LoadingComplete = false;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (NSAsset Asset in assetDictionary.Values)
            {
                if (!Asset.Loaded)
                {
                    Asset.Load(content, Game.GraphicsDevice);
                }
            }
        }
        #endregion

        bool Loaded = false;

        #region PROPERTY(IES)
        public string Root { get; private set; }
        public bool LoadingComplete { get; private set; }
        public Dictionary<string, NSAsset> Assets { get { return assetDictionary; } }
        #endregion
    }
}
