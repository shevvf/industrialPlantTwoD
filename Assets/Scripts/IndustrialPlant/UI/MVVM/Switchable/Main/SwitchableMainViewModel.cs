using IndustrialPlant.Data.StaticData.Configs.Audio;
using IndustrialPlant.Infrastructure.GlobalServices.AudioService;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Transitional;
using IndustrialPlant.UI.MVVM.Transitional;

using ObservableCollections;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainViewModel
    {
        private readonly SwitchableMainModel switchableMainModel;
        private readonly TransitionalController transitionalController;
        private readonly UISoundsConfig uISoundsConfig;
        private readonly IAudio audio;

        public ObservableDictionary<int, int> FactoriesLevel => switchableMainModel.FactoriesLevel;

        public SwitchableMainViewModel(SwitchableMainModel switchableMainModel, TransitionalController transitionalController,
            UISoundsConfig uISoundsConfig, IAudio audio)
        {
            this.switchableMainModel = switchableMainModel;
            this.transitionalController = transitionalController;
            this.uISoundsConfig = uISoundsConfig;
            this.audio = audio;
        }

        public async void OnFactoryClick(int factoryId)
        {
            audio.PlayUISound(uISoundsConfig.Touch);
            switchableMainModel.ClickedFactoryId.OnNext(factoryId);

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