using System;
using IndustrialPlant.UI.Items.Currency;
using IndustrialPlant.UI.Items.IndustrialFactory;
using IndustrialPlant.UI.MVVM.MainHUD.MainHUD;

using R3;
using UnityEngine;
using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyViewModel : IDisposable
    {
        private readonly CurrencyModel currencyModel;
        private readonly FactoryBuyModel factoryBuyModel;

        private readonly CompositeDisposable disposable = new();

        public ReactiveProperty<int> CurrentFactoryId => factoryBuyModel.CurrentFactory.Value.FactoryId;
        public ReactiveProperty<int> CurrentFactoryPrice => factoryBuyModel.CurrentFactory.Value.FactoryPrice;
        public ReactiveProperty<int> CurrentFactoryReward => factoryBuyModel.CurrentFactory.Value.FactoryReward;
        public ReactiveProperty<int> CurrentFactoryMiningRate => factoryBuyModel.CurrentFactory.Value.FactoryMiningRate;
        public ReactiveProperty<int> CurrentFactoryRequiredTimeSec => factoryBuyModel.CurrentFactory.Value.FactoryRequiredTimeSec;
        public ReactiveProperty<string> CurrentFactoryName => factoryBuyModel.CurrentFactory.Value.FactoryName;
        public ReactiveProperty<IndustrialFactoryModel> CurrentFactoryModel => factoryBuyModel.CurrentFactory;

        public FactoryBuyViewModel(CurrencyModel currencyModel, FactoryBuyModel factoryBuyModel)
        {
            this.currencyModel = currencyModel;
            this.factoryBuyModel = factoryBuyModel;

            CurrentFactoryName.Subscribe(a =>
            {
                Debug.Log(a);
            });

            CurrentFactoryModel.Subscribe(a => {Debug.Log(a.FactoryName); Debug.Log(CurrentFactoryName.Value); });
        }

        public void BuyFactory()
        {
            if (currencyModel.Coins.Value < CurrentFactoryPrice.Value)
            {
                Debug.Log("Not Enouth Coins");
                return;
            }

            currencyModel.Coins.Value -= CurrentFactoryPrice.Value;

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