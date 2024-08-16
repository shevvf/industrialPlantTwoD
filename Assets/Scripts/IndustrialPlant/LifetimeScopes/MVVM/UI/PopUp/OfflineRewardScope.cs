using IndustrialPlant.UI.MVVM.Base.Views;
using IndustrialPlant.UI.MVVM.PopUp.OfflineReward;

using UnityEngine;

namespace IndustrialPlant.LifetimeScopes.MVVM.UI.PopUp
{
    public class OfflineRewardScope : PopUpView<OfflineRewardView, OfflineRewardViewModel>
    {
        [field: SerializeField] public OfflineRewardView.View View { get; private set; }
    }
}