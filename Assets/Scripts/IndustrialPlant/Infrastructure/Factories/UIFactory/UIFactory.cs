using IndustrialPlant.UI.MVVM.MainHUD;
using IndustrialPlant.UI.MVVM.MainHUD.MainHUD;

using VContainer.Unity;

namespace IndustrialPlant.Infrastructure.Factories.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private readonly MainHUDController mainHUDController;
        private readonly SwitchableController switchableController;
        private readonly PopUpController popUpController;

        public UIFactory(MainHUDController mainHUDController, SwitchableController switchableController, PopUpController popUpController)
        {
            this.mainHUDController = mainHUDController;
            this.switchableController = switchableController;
            this.popUpController = popUpController;
        }

        void IStartable.Start()
        {
            CreateMainHUD();
            CreateInitSwitchable();
            CreateEnterPopUps();
        }

        public void CreateMainHUD()
        {
            mainHUDController.InitializeMainHUD();
        }

        public void CreateInitSwitchable()
        {
            switchableController.InitializeSwitchable();
        }

        public void CreateEnterPopUps()
        {
            popUpController.InitializeEnterPopUps();
        }
    }
}