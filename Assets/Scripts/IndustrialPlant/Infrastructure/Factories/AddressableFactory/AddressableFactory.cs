using Cysharp.Threading.Tasks;

using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;
using IndustrialPlant.Infrastructure.Factories.BaseFactory;

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace IndustrialPlant.Infrastructure.Factories.AddressableFactory
{
    public class AddressableFactory : IAddressableFactory
    {
        private readonly IAssetProvider assetProvider;
        private readonly IFactory factory;

        public AddressableFactory(IAssetProvider assetProvider, IFactory factory)
        {
            this.assetProvider = assetProvider;
            this.factory = factory;
        }

        public async UniTask<GameObject> CreateByReference(AssetReference assetReference, Transform parent = null)
        {
            GameObject gameObject = await assetProvider.Load<GameObject>(assetReference);
            return factory.CreatePrefab(gameObject, parent);
        }

        public async UniTask<GameObject> CreateByName(string assetName, Transform parent = null)
        {
            GameObject gameObject = await assetProvider.Load<GameObject>(assetName);
            return factory.CreatePrefab(gameObject, parent);
        }
    }
}