using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.UI.MVVM.Base.Views;

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace IndustrialPlant.UI.MVVM.Base.Controller
{
    public class ViewController : IViewController
    {
        private readonly PanelsConfig panelsConfig;
        private readonly Transform targetParent;
        private readonly IViewFactory viewFactory;

        private readonly List<IView> instantiatedViews = new();

        public ViewController(PanelsConfig panelsConfig, Transform targetParent, IViewFactory viewFactory)
        {
            this.panelsConfig = panelsConfig;
            this.targetParent = targetParent;
            this.viewFactory = viewFactory;
        }

        public virtual void CloseView<TView>() where TView : IView
        {
            IView view = instantiatedViews.Find(v => v is TView);
            if (view == null)
            {
                return;
            }
            view.CloseView();
        }

        public virtual async UniTask<IView> OpenViewAsync<TView>() where TView : Component, IView
        {
            IView view = instantiatedViews.Find(v => v is TView);
            if (view == null)
            {
                AssetReference viewPrefab = panelsConfig.Assets.Find(v => v.MonoBehaviour.GetType() == typeof(TView)).Asset;
                view = await viewFactory.CreateViewAsync(viewPrefab, targetParent);
                instantiatedViews.Add(view);
            }
            view.OpenView();
            return view;
        }

        public virtual async UniTask SwitchViewAsync<TView>() where TView : Component, IView
        {
            IView view = instantiatedViews.Find(v => v is TView);
            if (view == null)
            {
                AssetReference viewPrefab = panelsConfig.Assets.Find(v => v.MonoBehaviour.GetType() == typeof(TView)).Asset;
                view = await viewFactory.CreateViewAsync(viewPrefab, targetParent);
                instantiatedViews.Add(view);
                view.OpenView();
                return;
            }
            view.SwitchView();
        }
    }
}