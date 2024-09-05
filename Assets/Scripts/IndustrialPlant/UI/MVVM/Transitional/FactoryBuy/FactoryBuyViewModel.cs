using System;

using IndustrialPlant.Data.StaticData.Configs.Audio;
using IndustrialPlant.Infrastructure.GlobalServices.AudioService;
using IndustrialPlant.UI.Items.Currency;
using IndustrialPlant.UI.Items.IndustrialFactory;

using R3;

using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyViewModel : IDisposable
    {
        private readonly CurrencyModel currencyModel;
        private readonly FactoryBuyModel factoryBuyModel;
        private readonly UISoundsConfig uISoundsConfig;
        private readonly IAudio audio;

        private readonly CompositeDisposable disposable = new();

        public ReactiveProperty<int> CurrentFactoryId => factoryBuyModel.CurrentFactory.Value.FactoryId;
        public ReactiveProperty<int> CurrentFactoryPrice => factoryBuyModel.CurrentFactory.Value.FactoryPrice;
        public ReactiveProperty<int> CurrentFactoryReward => factoryBuyModel.CurrentFactory.Value.FactoryReward;
        public ReactiveProperty<int> CurrentFactoryMiningRate => factoryBuyModel.CurrentFactory.Value.FactoryMiningRate;
        public ReactiveProperty<int> CurrentFactoryRequiredTimeSec => factoryBuyModel.CurrentFactory.Value.FactoryRequiredTimeSec;
        public ReactiveProperty<string> CurrentFactoryName => factoryBuyModel.CurrentFactory.Value.FactoryName;
        public ReactiveProperty<IndustrialFactoryModel> CurrentFactoryModel => factoryBuyModel.CurrentFactory;

        public FactoryBuyViewModel(CurrencyModel currencyModel, FactoryBuyModel factoryBuyModel,
            UISoundsConfig uISoundsConfig, IAudio audio)
        {
            this.currencyModel = currencyModel;
            this.factoryBuyModel = factoryBuyModel;
            this.uISoundsConfig = uISoundsConfig;
            this.audio = audio;
        }

        public void BuyFactory()
        {
            if (currencyModel.Coins.Value < CurrentFactoryPrice.Value)
            {
                PlayFailSound();
                Debug.Log("Not Enouth Coins");
                return;
            }

            currencyModel.Coins.Value -= CurrentFactoryPrice.Value;
            PlayBuySound();
            StartBuildingTimer();
        }

        private void StartBuildingTimer()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(1), UnityTimeProvider.UpdateIgnoreTimeScale)
                .Subscribe(_ =>
                {
                    OnSecondGone();

                    if (CurrentFactoryRequiredTimeSec.Value <= 0)
                    {
                        FinishBuilding();
                        disposable.Clear();
                    }
                })
                .AddTo(disposable);
        }

        public void PlayCloseSound()
        {
            audio.PlayUISound(uISoundsConfig.Grow);
        }

        public void PlayBuySound()
        {
            audio.PlayUISound(uISoundsConfig.Buy);
        }

        public void PlayFailSound()
        {
            audio.PlayUISound(uISoundsConfig.Fail);
        }

        private void OnSecondGone()
        {
            CurrentFactoryRequiredTimeSec.Value -= 1;
        }

        private void FinishBuilding()
        {
            currencyModel.Cubes.Value += CurrentFactoryMiningRate.Value;
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}