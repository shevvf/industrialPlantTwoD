using System;

using IndustrialPlant.App.StateMachine;
using IndustrialPlant.Audio;
using IndustrialPlant.Data.Json;
using IndustrialPlant.Data.StaticData.Configs.Audio;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;
using IndustrialPlant.Infrastructure.Factories.AddressableFactory;
using IndustrialPlant.Infrastructure.Factories.BaseFactory;
using IndustrialPlant.Infrastructure.GlobalServices.AudioService;
using IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService;
using IndustrialPlant.Infrastructure.GlobalServices.WebRequestService;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.Infrastructure.Systems.SaveLoadSystem;
using IndustrialPlant.UI.Items.Currency;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes
{
    public class RootScope : LifetimeScope
    {
        [Serializable]
        public class ScriptableConfigs
        {
            [field: SerializeField] public UISoundsConfig UISoundsConfig { get; private set; }
        }

        [field: SerializeField] public ScriptableConfigs Configs { get; private set; }
        [field: SerializeField] public AudioFolder AudioFolder { get; private set; }
        [field: SerializeField] public AppJsonData AppJsonData { get; private set; }
        [field: SerializeField] public UserData UserData { get; private set; }

        private IContainerBuilder containerBuilder;

        protected override void Configure(IContainerBuilder builder)
        {
            containerBuilder = builder;

            RegisterSaveLoadSystem();
            RegisterAppStateMachine();
            RegisterSceneLoaderService();
            RegisterDataService();
            RegisterWebRequestService();
            RegisterAssetProvider();
            RegisterGlobalFactories();
            RegisterAudioService();
            RegisterModels();
            RegisterInstance();
        }
        private void RegisterSaveLoadSystem()
        {
            containerBuilder.RegisterEntryPoint<SaveLoadSystem>();
        }

        private void RegisterAppStateMachine()
        {
            containerBuilder.Register<AppStateMachine>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterSceneLoaderService()
        {
            containerBuilder.Register<SceneLoaderService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterDataService()
        {
            containerBuilder.Register<DataService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterWebRequestService()
        {
            containerBuilder.Register<WebRequestService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterAssetProvider()
        {
            containerBuilder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterAudioService()
        {
            containerBuilder.Register<AudioService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterGlobalFactories()
        {
            containerBuilder.Register<Factory>(Lifetime.Singleton).AsImplementedInterfaces();
            containerBuilder.Register<AddressableFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterModels()
        {
            containerBuilder.Register<CurrencyModel>(Lifetime.Singleton).AsSelf();
            containerBuilder.Register<IndustrialPlantModel>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterInstance()
        {
            containerBuilder.RegisterInstance(Configs.UISoundsConfig);

            containerBuilder.RegisterInstance(AudioFolder);

            containerBuilder.RegisterInstance(AppJsonData);
            containerBuilder.RegisterInstance(UserData);
        }
    }
}