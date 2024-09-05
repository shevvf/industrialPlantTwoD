using Cysharp.Threading.Tasks;

using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Main;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;
using IndustrialPlant.UI.MVVM.Base.Controller;
using IndustrialPlant.UI.MVVM.Base.Views;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class SwitchableController : ViewController
    {
        private IView currentView;

        public SwitchableController(SwitchablePanelsConfig panelsConfig, MainCanvasScope.UIFolder uIContainersFolder, IViewFactory viewFactory)
            : base(panelsConfig, uIContainersFolder.SwitchablePanelsHolder, viewFactory)
        {
        }

        public async void InitializeSwitchable()
        {
            await OpenViewAsync<SwitchableMainScope>();
        }

        public override async UniTask<IView> OpenViewAsync<TView>()
        {
            if (currentView != null && currentView.GetType() == typeof(TView))
                return currentView;

            IView newView = await base.OpenViewAsync<TView>();

            currentView?.CloseView();
            currentView = newView;
            return newView;
        }
    }
}