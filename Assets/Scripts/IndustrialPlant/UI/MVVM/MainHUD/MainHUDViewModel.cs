using System;
using System.Numerics;

using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;

using R3;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDViewModel : IDisposable
    {
        private readonly CompositeDisposable disposable = new();

        private readonly SwitchableController switchableController;
        private readonly MainHUDModel mainHUDModel;

        public ReactiveProperty<BigInteger> CurrentCoins => mainHUDModel.currencyModel.Coins;
        public ReactiveProperty<BigInteger> CurrentCubes => mainHUDModel.currencyModel.Cubes;
        public ReactiveProperty<BigInteger> CubesPerSecond => mainHUDModel.currencyModel.CubesPerSecond;
        public ReactiveProperty<BigInteger> CurrentSpecialCoins => mainHUDModel.currencyModel.SpecialCoins;

        public MainHUDViewModel(SwitchableController switchableController, MainHUDModel mainHUDModel)
        {
            this.switchableController = switchableController;
            this.mainHUDModel = mainHUDModel;
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
            CurrentCubes.Value += CubesPerSecond.Value;
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}