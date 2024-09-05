using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Base.Views
{
    public class PopUpView<TView, TViewModel> : View<TView, TViewModel>
         where TView : class, IEntryPoint
         where TViewModel : class
    {
        public override void OpenView()
        {
            Debug.Log("PopUpView");
            base.OpenView();
        }

        public override void CloseView()
        {
            base.CloseView();
        }

        public override void SwitchView()
        {
            base.SwitchView();
        }
    }
}