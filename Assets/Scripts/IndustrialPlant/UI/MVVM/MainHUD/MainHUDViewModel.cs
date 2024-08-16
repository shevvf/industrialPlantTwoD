using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDViewModel
    {
        private readonly SwitchableController switchableController;

        public MainHUDViewModel(SwitchableController switchableController)
        {
            this.switchableController = switchableController;
        }

        public async void OnMainClick()
        {
            await switchableController.OpenViewAsync<SwitchableMainScope>();
        }

        public async void OnUpgradeClick()
        {
            await switchableController.OpenViewAsync<SwitchableUpgradeScope>();
        }

        public async void OnFriendsClick()
        {
            await switchableController.OpenViewAsync<SwitchableFriendsScope>();
        }

        public async void OnTasksClick()
        {
            await switchableController.OpenViewAsync<SwitchableTasksScope>();
        }

        public async void OnTonClick()
        {
            await switchableController.OpenViewAsync<SwitchableTonScope>();
        }
    }
}