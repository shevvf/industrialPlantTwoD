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

        public ReactiveProperty<BigInteger> CurrentCoins => mainHUDModel.CurrentCoins;
        public ReactiveProperty<BigInteger> CurrentCubes => mainHUDModel.CurrentCubes;
        public ReactiveProperty<BigInteger> CubesPerSecond => mainHUDModel.CubesPerSecond;
        public ReactiveProperty<BigInteger> CurrentDiamonds => mainHUDModel.CurrentDiamonds;
        public ReactiveProperty<BigInteger> CurrentSpecialCoins => mainHUDModel.CurrentSpecialCoins;

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
            mainHUDModel.CurrentCubes.Value += mainHUDModel.CubesPerSecond.Value;
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}