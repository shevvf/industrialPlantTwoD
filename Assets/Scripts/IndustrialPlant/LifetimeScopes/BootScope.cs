using IndustrialPlant.App.EntryPoint;

using VContainer;
using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes
{
    public class BootScope : LifetimeScope
    {
        private IContainerBuilder containerBuilder;

        protected override void Configure(IContainerBuilder builder)
        {
            containerBuilder = builder;

            RegisterEntryPoint();
        }

        private void RegisterEntryPoint()
        {
            containerBuilder.RegisterEntryPoint<AppEntryPoint>();
        }
    }
}