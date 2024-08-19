using IndustrialPlant.UI.MVVM.Base.Views;
using IndustrialPlant.UI.MVVM.Transitional.FactoryUpgrade;

using UnityEngine;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.Transitional
{
    public class FactoryUpgradeScope : TransitionView<FactoryUpgradeView, FactoryUpgradeViewModel>
    {
        [field: SerializeField] public FactoryUpgradeView.View View { get; private set; }
    }
}