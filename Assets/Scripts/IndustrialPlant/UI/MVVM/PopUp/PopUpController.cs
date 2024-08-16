using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Main;
using IndustrialPlant.LifetimeScopes.MVVM.UI.PopUp;
using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.UI.MVVM.Base.Controller;

namespace IndustrialPlant.UI.MVVM.MainHUD
{
    public class PopUpController : ViewController
    {
        public PopUpController(PopUpPanelsConfig panelsConfig, MainCanvasScope.UIFolder uIContainersFolder, IViewFactory viewFactory)
            : base(panelsConfig, uIContainersFolder.PopUpPanelsHolder, viewFactory)
        {
        }

        public void InitializeEnterPopUps()
        {

        }


        public async void OpenOfflineReward()
        {
            await OpenViewAsync<OfflineRewardScope>();
        }

        public void CloseOfflineReward()
        {
            CloseView<OfflineRewardScope>();
        }

        public void OpenGambleWheel()
        {

        }

        public void CloseGambleWheel()
        {

        }
    }
}