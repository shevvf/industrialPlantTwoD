using System;

using Framework.Extensions;

using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Transitional;

using R3;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyView : VCObject<FactoryBuyScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public Image FactoryImage { get; private set; }

            [field: SerializeField] public TMP_Text NameText { get; private set; }

            [field: SerializeField] public TMP_Text LevelText { get; private set; }

            [field: SerializeField] public TMP_Text MiningRateText { get; private set; }

            [field: SerializeField] public TMP_Text PriceText { get; private set; }

            [field: SerializeField] public TMP_Text RewardText { get; private set; }

            [field: SerializeField] public TMP_Text RequiredTimeText { get; private set; }

            [field: SerializeField] public Button BuyButton { get; private set; }

            [field: SerializeField] public Button CloseButton { get; private set; }
        }

        private readonly FactoryBuyViewModel factoryBuyViewModel;

        public FactoryBuyView(FactoryBuyViewModel factoryBuyViewModel)
        {
            this.factoryBuyViewModel = factoryBuyViewModel;
        }

        void IStartable.Start()
        {
            ButtonsSubscribe();
            TextSubscribe();
        }

        private void ButtonsSubscribe()
        {
            Scope.View.CloseButton.OnClickAsObservable().Subscribe(_ => Scope.CloseView()).AddTo(Scope);
            Scope.View.BuyButton.OnClickAsObservable().Subscribe(_ => factoryBuyViewModel.BuyFactory()).AddTo(Scope);
        }

        private void TextSubscribe()
        {
            factoryBuyViewModel.CurrentFactoryMiningRate.SubscribeToTMPText(Scope.View.MiningRateText).AddTo(Scope);
            factoryBuyViewModel.CurrentFactoryPrice.SubscribeToTMPText(Scope.View.PriceText).AddTo(Scope);
            factoryBuyViewModel.CurrentFactoryRequiredTimeSec.SubscribeToTMPText(Scope.View.RequiredTimeText).AddTo(Scope);
            factoryBuyViewModel.CurrentFactoryReward.SubscribeToTMPText(Scope.View.RewardText).AddTo(Scope);
            factoryBuyViewModel.CurrentFactoryName.SubscribeToTMPText(Scope.View.NameText).AddTo(Scope);

            //  Debug.Log(factoryBuyViewModel.CurrentFactoryId.Value);
        }
    }
}