using IndustrialPlant.LifetimeScopes.MVVM.UI.Transitional;
using IndustrialPlant.UI.MVVM.Transitional;

using ObservableCollections;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainViewModel
    {
        private readonly SwitchableMainModel switchableMainModel;
        private readonly TransitionalController transitionalController;

        public ObservableDictionary<int, int> FactoriesLevel => switchableMainModel.FactoriesLevel;

        public SwitchableMainViewModel(SwitchableMainModel switchableMainModel, TransitionalController transitionalController)
        {
            this.switchableMainModel = switchableMainModel;
            this.transitionalController = transitionalController;
        }

        public async void OnFactoryClick(int factoryId)
        {
            switchableMainModel.CurrentFactoryId.Value = factoryId;

            if (FactoriesLevel[factoryId] <= 0)
            {
                await transitionalController.OpenViewAsync<FactoryBuyScope>();
            }
            else
            {
                await transitionalController.OpenViewAsync<FactoryUpgradeScope>();
            }
        }
    }
}