using System;
using System.Numerics;

using R3;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainViewModel : IDisposable
    {
        private readonly SwitchableMainModel switchableMainModel;

        private readonly CompositeDisposable disposable = new();

        public ReactiveProperty<BigInteger> CurrentMoney => switchableMainModel.CurrentMoney;
        public ReactiveProperty<BigInteger> IncomePerTap => switchableMainModel.IncomePerTap;
        public ReactiveProperty<BigInteger> IncomePerSecond => switchableMainModel.IncomePerSecond;
        public ReactiveProperty<int> CurrentEnergy => switchableMainModel.CurrentEnergy;
        public ReactiveProperty<int> MaxEnergy => switchableMainModel.MaxEnergy;

        public SwitchableMainViewModel(SwitchableMainModel switchableMainModel)
        {
            this.switchableMainModel = switchableMainModel;
        }

        public void StartAutoMining()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(1), UnityTimeProvider.UpdateIgnoreTimeScale)
                .Subscribe(_ =>
                {
                    OnSecondGone();
                })
                .AddTo(disposable);
        }

        public void OnBoobsClick(UnityEngine.Vector3 hitPoint)
        {
            if (CurrentEnergy.Value <= 0)
                return;

            CurrentMoney.Value += IncomePerTap.Value;
            CurrentEnergy.Value -= 1;
        }

        public void OnSecondGone()
        {
            CurrentMoney.Value += IncomePerSecond.Value;

            if (CurrentEnergy.Value >= MaxEnergy.Value)
                return;
            CurrentEnergy.Value += 1;
        }

        public void OnSettingsClick()
        {

        }

        public void OnBoostClick()
        {

        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}