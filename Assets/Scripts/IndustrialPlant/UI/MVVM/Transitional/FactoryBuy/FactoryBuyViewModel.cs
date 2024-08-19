using System;

using IndustrialPlant.UI.MVVM.MainHUD.MainHUD;

using R3;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyViewModel : IDisposable
    {
        private readonly MainHUDModel mainHUDModel;
        private readonly FactoryBuyModel factoryBuyModel;

        private readonly CompositeDisposable disposable = new();
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
            if (mainHUDModel.CurrentCoins.Value < CurrentFactoryPrice.Value)
                return;

            mainHUDModel.CurrentCoins.Value -= CurrentFactoryPrice.Value;
            mainHUDModel.CurrentDiamonds.Value += CurrentFactoryReward.Value;

            StartBuildingTimer();
        }

        private void StartBuildingTimer()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(CurrentFactoryRequiredTimeSec.Value), UnityTimeProvider.UpdateIgnoreTimeScale)
                .Subscribe(_ =>
                {
                    FinishBuilding();
                })
                .AddTo(disposable);
        }

        private void OnSecondGone()
        {
            CurrentFactoryRequiredTimeSec.Value -= 1;
        }

        private void FinishBuilding()
        {
            mainHUDModel.CubesPerSecond.Value += CurrentFactoryMiningRate.Value;
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}