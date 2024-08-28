using AnimalSimulation.Data.Json;

using IndustrialPlant.App.StateMachine;
using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.UI.Items.IndustrialFactory;
using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;
using IndustrialPlant.Infrastructure.Factories.AddressableFactory;
using IndustrialPlant.Infrastructure.Factories.BaseFactory;
using IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService;
using IndustrialPlant.Infrastructure.GlobalServices.WebRequestService;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.Infrastructure.Systems.SaveLoadSystem;

using UnityEngine;

using VContainer;
using VContainer.Unity;
using IndustrialPlant.UI.Items.Currency;

namespace IndustrialPlant.LifetimeScopes
{
    public class RootScope : LifetimeScope
    {
        [field: SerializeField] public SwitchablePanelsConfig SwitchablePanelsConfig { get; private set; }
        [field: SerializeField] public MainHUDConfig MainHUDConfig { get; private set; }
        [field: SerializeField] public PopUpPanelsConfig PopUpPanelsConfig { get; private set; }
        [field: SerializeField] public TransitionalPanelsConfig TransitionalPanelsConfig { get; private set; }
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
            containerBuilder.RegisterInstance(SwitchablePanelsConfig);
            containerBuilder.RegisterInstance(MainHUDConfig);
            containerBuilder.RegisterInstance(PopUpPanelsConfig);
            containerBuilder.RegisterInstance(TransitionalPanelsConfig);
            containerBuilder.RegisterInstance(AppJsonData);

            containerBuilder.RegisterInstance(UserData);
        }
    }
}