using IndustrialPlant.UI.MVVM.Base.Views;
using IndustrialPlant.UI.MVVM.Switchable.Main;

using UnityEngine;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable
{
    public class SwitchableMainScope : SwitchableView<SwitchableMainView, SwitchableMainViewModel>
    {
        [field: SerializeField] public SwitchableMainView.View View { get; private set; }
    }
}