using IndustrialPlant.UI.MVVM.Base.Views;
using IndustrialPlant.UI.MVVM.Transitional.FactoryBuy;

using UnityEngine;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.Transitional
{
    public class FactoryBuyScope : TransitionView<FactoryBuyView, FactoryBuyViewModel>
    {
        [field: SerializeField] public FactoryBuyView.View View { get; private set; }
    }
}