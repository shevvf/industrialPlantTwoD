using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Main;
using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.UI.MVVM.Base.Controller;

namespace IndustrialPlant.UI.MVVM.MainHUD
{
    public class MainHUDController : ViewController
    {
        public MainHUDController(MainHUDConfig panelsConfig, MainCanvasScope.UIFolder uIContainersFolder, IViewFactory viewFactory)
            : base(panelsConfig, uIContainersFolder.MainHUDHolder, viewFactory)
        {
        }

        public async void InitializeMainHUD()
        {
            await OpenViewAsync<MainHUDScope>();
        }
    }
}