using IndustrialPlant.UI.MVVM.Base.Views;
using IndustrialPlant.UI.MVVM.MainHUD.MainHUD;

using UnityEngine;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.Main
{
    public class MainHUDScope : BaseView<MainHUDView, MainHUDViewModel>
    {
        [field: SerializeField] public MainHUDView.View View { get; private set; }
    }
}