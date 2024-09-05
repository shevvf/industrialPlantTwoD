using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Base.Views
{
    public class BaseView<TView, TViewModel> : View<TView, TViewModel>
         where TView : class, IEntryPoint
         where TViewModel : class
    {
        public override void OpenView()
        {
            Debug.Log("BaseView");
            return;
        }

        public override void CloseView()
        {
            return;
        }

        public override void SwitchView()
        {
            return;
        }
    }
}