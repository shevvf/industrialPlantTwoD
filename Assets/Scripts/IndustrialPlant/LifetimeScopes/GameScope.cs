using System;

using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.Infrastructure.Factories.GameFactory;
using IndustrialPlant.Infrastructure.GameServices.ApplicationFocusService;
using IndustrialPlant.Infrastructure.GameServices.CalculatorService;
using IndustrialPlant.Infrastructure.GameServices.TimeService;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes
{
    public class GameScope : LifetimeScope
    {
        [Serializable]
        public class MainGameFolder
        {
            [field: SerializeField] public Transform CanvasHolder { get; private set; }
        }

        [field: SerializeField] public MainGameFolder Folder { get; private set; }
        [field: SerializeField] public SwitchablePanelsConfig SwitchablePanelsConfig { get; private set; }
        [field: SerializeField] public MainHUDConfig MainHUDConfig { get; private set; }
        [field: SerializeField] public PopUpPanelsConfig PopUpPanelsConfig { get; private set; }
        [field: SerializeField] public TransitionalPanelsConfig TransitionalPanelsConfig { get; private set; }

        private IContainerBuilder containerBuilder;

        protected override void Configure(IContainerBuilder builder)
        {
            containerBuilder = builder;

            RegisterGameFactories();
            RegisterCalculatorService();
            RegisterApplicationFocusService();
            RegisterTimeService();
            RegisterInstance();
        }

        private void RegisterGameFactories()
        {
            containerBuilder.RegisterEntryPoint<GameFactory>();
        }

        private void RegisterApplicationFocusService()
        {
            containerBuilder.Register<ApplicationFocusService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterTimeService()
        {
            containerBuilder.Register<TimeService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterCalculatorService()
        {
            containerBuilder.Register<CalculatorService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterInstance()
        {
            containerBuilder.RegisterInstance(Folder);

            containerBuilder.RegisterInstance(SwitchablePanelsConfig);
            containerBuilder.RegisterInstance(MainHUDConfig);
            containerBuilder.RegisterInstance(PopUpPanelsConfig);
            containerBuilder.RegisterInstance(TransitionalPanelsConfig);
        }
    }
}