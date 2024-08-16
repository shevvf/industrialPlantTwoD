using VContainer;
using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes.MVVM
{
    public class MVVMScope<TView, TViewModel> : LifetimeScope
        where TView : IEntryPoint
        where TViewModel : class
    {
        protected IContainerBuilder ContainerBuilder { get; set; }

        protected override void Configure(IContainerBuilder builder)
        {
            ContainerBuilder = builder;

            RegisterView();
            RegisterViewModel();
        }

        private void RegisterView()
        {
            ContainerBuilder.RegisterEntryPoint<TView>();
        }

        private void RegisterViewModel()
        {
            ContainerBuilder.Register<TViewModel>(Lifetime.Singleton).AsSelf();
        }
    }
}