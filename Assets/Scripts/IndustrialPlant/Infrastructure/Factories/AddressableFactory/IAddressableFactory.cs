using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace IndustrialPlant.Infrastructure.Factories.AddressableFactory
{
    public interface IAddressableFactory
    {
        UniTask<GameObject> CreateByReference(AssetReference assetReference, Transform parent = null);

        UniTask<GameObject> CreateByName(string assetName, Transform parent = null);
    }
}