using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Main;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;
using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.UI.MVVM.Base.Controller;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class SwitchableController : ViewController
    {
        public SwitchableController(SwitchablePanelsConfig panelsConfig, MainCanvasScope.UIFolder uIContainersFolder, IViewFactory viewFactory)
            : base(panelsConfig, uIContainersFolder.SwitchablePanelsHolder, viewFactory)
        {
        }

        public async void InitializeSwitchable()
        {
            await OpenViewAsync<SwitchableMainScope>();
        }


    }
}