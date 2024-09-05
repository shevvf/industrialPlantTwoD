using IndustrialPlant.UI.MVVM.Base.Views;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace IndustrialPlant.Infrastructure.Factories.ViewFactory
{
    public interface IViewFactory
    {
        UniTask<IView> CreateViewAsync(AssetReference assetReference, Transform parent);
    }
}