using System;
using System.Numerics;

using IndustrialPlant.Data.StaticData.Configs.Audio;
using IndustrialPlant.Infrastructure.GlobalServices.AudioService;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;

using R3;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDViewModel : IDisposable
    {
        private readonly CompositeDisposable disposable = new();

        private readonly SwitchableController switchableController;
        private readonly MainHUDModel mainHUDModel;
        private readonly UISoundsConfig uISoundsConfig;
        private readonly IAudio audio;

        public ReactiveProperty<BigInteger> CurrentCoins => mainHUDModel.currencyModel.Coins;
        public ReactiveProperty<BigInteger> CurrentCubes => mainHUDModel.currencyModel.Cubes;
        public ReactiveProperty<BigInteger> CubesPerSecond => mainHUDModel.currencyModel.CubesPerSecond;
        public ReactiveProperty<BigInteger> CurrentSpecialCoins => mainHUDModel.currencyModel.SpecialCoins;

        public MainHUDViewModel(SwitchableController switchableController, MainHUDModel mainHUDModel,
            UISoundsConfig uISoundsConfig, IAudio audio)
        {
            this.switchableController = switchableController;
            this.mainHUDModel = mainHUDModel;
            this.uISoundsConfig = uISoundsConfig;
            this.audio = audio;
        }

        public async void OnMainClick()
        {
            PlaySound();
            await switchableController.OpenViewAsync<SwitchableMainScope>();
        }

        public async void OnUpgradeClick()
        {
            PlaySound();
            await switchableController.OpenViewAsync<SwitchableUpgradeScope>();
        }

        public async void OnFriendsClick()
        {
            PlaySound();
            await switchableController.OpenViewAsync<SwitchableFriendsScope>();
        }

        public async void OnTasksClick()
        {
            PlaySound();
            await switchableController.OpenViewAsync<SwitchableTasksScope>();
        }

        public async void OnTonClick()
        {
            PlaySound();
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

        private void PlaySound()
        {
            audio.PlayUISound(uISoundsConfig.Button);
        }

        private void OnSecondGone()
        {
            mainHUDModel.currencyModel.Cubes.Value += mainHUDModel.currencyModel.CubesPerSecond.Value;
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}