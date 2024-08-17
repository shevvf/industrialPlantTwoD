using System;
using System.Numerics;

using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;
using IndustrialPlant.UI.MVVM.Switchable.Main;

using R3;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDViewModel : IDisposable
    {
        private readonly CompositeDisposable disposable = new();

        private readonly SwitchableController switchableController;
        private readonly SwitchableMainModel switchableMainModel;

        public ReactiveProperty<BigInteger> CurrentCoins => switchableMainModel.CurrentCoins;
        public ReactiveProperty<BigInteger> CurrentCubes => switchableMainModel.CurrentCubes;
        public ReactiveProperty<BigInteger> CubesPerSecond => switchableMainModel.CubesPerSecond;
        public ReactiveProperty<BigInteger> CurrentDiamonds => switchableMainModel.CurrentDiamonds;
        public ReactiveProperty<BigInteger> CurrentSpecialCoins => switchableMainModel.CurrentSpecialCoins;

        public MainHUDViewModel(SwitchableController switchableController, SwitchableMainModel switchableMainModel)
        {
            this.switchableController = switchableController;
            this.switchableMainModel = switchableMainModel;
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

        private void OnSecondGone()
        {
            switchableMainModel.CurrentCubes.Value += switchableMainModel.CubesPerSecond.Value;
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}