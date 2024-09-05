using System;

using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.PopUp;

using R3;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.PopUp.OfflineReward
{
    public class OfflineRewardView : VCObject<OfflineRewardScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public Button ClaimButton { get; private set; }
            [field: SerializeField] public Button GambleButton { get; private set; }
            [field: SerializeField] public TMP_Text EarnedCoinsText { get; private set; }
            [field: SerializeField] public TMP_Text TimeOfflineText { get; private set; }
        }

        private readonly OfflineRewardViewModel offlineRewardViewModel;

        public OfflineRewardView(OfflineRewardViewModel offlineRewardViewModel)
        {
            this.offlineRewardViewModel = offlineRewardViewModel;
        }

        void IStartable.Start()
        {
            ButtonsSubscribe();
            TextSubscribe();
        }

        private void ButtonsSubscribe()
        {
            Scope.View.ClaimButton.OnClickAsObservable().Subscribe(_ => offlineRewardViewModel.OnClaimClick()).AddTo(Scope);
            Scope.View.GambleButton.OnClickAsObservable().Subscribe(_ => offlineRewardViewModel.OnGambleClick()).AddTo(Scope);
        }

        private void TextSubscribe()
        {

        }
    }
}