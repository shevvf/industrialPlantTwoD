using System;

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

        private IContainerBuilder containerBuilder;

        protected override void Configure(IContainerBuilder builder)
        {
            containerBuilder = builder;

            RegisterGameFactories();
            RegisterCalculatorService();
            RegisterApplicationFocusService();
            RegisterTimeService();
            RegisterJointService();
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

        private void RegisterJointService()
        {
        }

        private void RegisterCalculatorService()
        {
            containerBuilder.Register<CalculatorService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterInstance()
        {
            containerBuilder.RegisterInstance(Folder);
        }
    }
}