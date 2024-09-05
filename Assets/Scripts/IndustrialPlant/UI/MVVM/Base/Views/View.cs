using IndustrialPlant.LifetimeScopes.MVVM;

namespace IndustrialPlant.UI.MVVM.Base.Views
{
    public class View<TView, TViewModel> : MVVMScope<TView, TViewModel>, IView
         where TView : class, IEntryPoint
         where TViewModel : class
    {
        public virtual void OpenView()
        {
            gameObject.SetActive(true);
        }

        public virtual void CloseView()
        {
            gameObject.SetActive(false);
        }

        public virtual void SwitchView()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}