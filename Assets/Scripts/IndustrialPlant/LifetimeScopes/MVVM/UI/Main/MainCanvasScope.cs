using System;

using IndustrialPlant.Infrastructure.Factories.UIFactory;
using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.UI.MVVM.MainHUD;
using IndustrialPlant.UI.MVVM.MainHUD.MainHUD;
using IndustrialPlant.UI.MVVM.PopUp.OfflineReward;
using IndustrialPlant.UI.MVVM.Switchable.Main;
using IndustrialPlant.UI.MVVM.Transitional;
using IndustrialPlant.UI.MVVM.Transitional.FactoryBuy;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.Main
{
    public class MainCanvasScope : LifetimeScope
    {
        [Serializable]
        public class UIFolder
        {
            [field: SerializeField] public Transform MainHUDHolder { get; private set; }
            [field: SerializeField] public Transform SwitchablePanelsHolder { get; private set; }
            [field: SerializeField] public Transform TransitionalPanelsHolder { get; private set; }
            [field: SerializeField] public Transform PopUpPanelsHolder { get; private set; }
        }

        [field: SerializeField] public UIFolder Folder { get; private set; }

        private IContainerBuilder containerBuilder;

        protected override void Configure(IContainerBuilder builder)
        {
            containerBuilder = builder;

            RegisterFactories();
            RegisterControllers();
            RegisterInstance();
            RegisterModels();
        }

        private void RegisterFactories()
        {
            containerBuilder.RegisterEntryPoint<UIFactory>().AsSelf();

            containerBuilder.Register<ViewFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
        private void RegisterControllers()
        {
            containerBuilder.Register<MainHUDController>(Lifetime.Singleton).AsSelf();
            containerBuilder.Register<SwitchableController>(Lifetime.Singleton).AsSelf();
            containerBuilder.Register<PopUpController>(Lifetime.Singleton).AsSelf();
            containerBuilder.Register<TransitionalController>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterModels()
        {
            containerBuilder.Register<MainHUDModel>(Lifetime.Singleton).AsSelf();

            containerBuilder.Register<SwitchableMainModel>(Lifetime.Singleton).AsSelf();

            containerBuilder.Register<FactoryBuyModel>(Lifetime.Singleton).AsSelf();

            containerBuilder.Register<OfflineRewardModel>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterInstance()
        {
            containerBuilder.RegisterInstance(Folder);
        }
    }
}