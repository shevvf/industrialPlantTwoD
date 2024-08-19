using IndustrialPlant.UI.MVVM.MainHUD.MainHUD;

using R3;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyViewModel
    {
        private readonly MainHUDModel mainHUDModel;
        private readonly FactoryBuyModel factoryBuyModel;

        // public ReactiveProperty<int> CurrentFactoryId => factoryBuyModel.CurrentFactoryId;
        public ReactiveProperty<int> CurrentFactoryPrice => factoryBuyModel.CurrentFactoryPrice;
        public ReactiveProperty<int> CurrentFactoryReward => factoryBuyModel.CurrentFactoryReward;
        public ReactiveProperty<int> CurrentFactoryMiningRate => factoryBuyModel.CurrentFactoryMiningRate;
        public ReactiveProperty<int> CurrentFactoryRequiredTimeSec => factoryBuyModel.CurrentFactoryRequiredTimeSec;
        public ReactiveProperty<string> CurrentFactoryName => factoryBuyModel.CurrentFactoryName;

        public FactoryBuyViewModel(MainHUDModel mainHUDModel, FactoryBuyModel factoryBuyModel)
        {
            this.mainHUDModel = mainHUDModel;
            this.factoryBuyModel = factoryBuyModel;
        }

        public void BuyFactory()
        {

        }
    }
}