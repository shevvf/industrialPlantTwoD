using IndustrialPlant.UI.MVVM.Base.Views;
using IndustrialPlant.UI.MVVM.Switchable.Tasks;
using IndustrialPlant.UI.MVVM.Transitional.FactoryBuy;
using UnityEngine;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable
{
    public class SwitchableTasksScope : SwitchableView<SwitchableTasksView, SwitchableTasksViewModel>
    {
        [field: SerializeField] public SwitchableTasksView.View View { get; private set; }
    }
}