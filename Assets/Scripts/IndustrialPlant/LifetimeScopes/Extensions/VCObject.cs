using VContainer;
using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes.Extensions
{
    public class VCObject<TScope> : IVCObject<TScope>
        where TScope : LifetimeScope
    {
        [Inject] private LifetimeScope LifetimeScope { get; set; }

        public TScope Scope => LifetimeScope as TScope;
    }
}