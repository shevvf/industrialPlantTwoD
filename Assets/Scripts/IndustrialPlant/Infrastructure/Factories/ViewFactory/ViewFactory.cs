using IndustrialPlant.Infrastructure.Factories.AddressableFactory;
using IndustrialPlant.UI.MVVM.Base.Views;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace IndustrialPlant.Infrastructure.Factories.ViewFactory
{
    public class ViewFactory : IViewFactory
    {
        private readonly IAddressableFactory addressableFactory;

        public ViewFactory(IAddressableFactory addressableFactory)
        {
            this.addressableFactory = addressableFactory;
        }

        public async UniTask<IView> CreateViewAsync(AssetReference assetReference, Transform parent)
        {
            GameObject gameObject = await addressableFactory.CreateByReference(assetReference, parent);
            IView view = gameObject.GetComponent<IView>();
            return view;
        }
    }
}