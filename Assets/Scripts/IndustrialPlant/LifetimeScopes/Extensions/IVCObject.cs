using VContainer.Unity;

namespace IndustrialPlant.LifetimeScopes.Extensions
{
    public interface IVCObject<TScope>
     where TScope : LifetimeScope
    {
        TScope Scope { get; }
    }
}