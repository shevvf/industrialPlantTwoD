using System;

using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Transitional;

using R3;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryUpgrade
{
    public class FactoryUpgradeView : VCObject<FactoryUpgradeScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public TMP_Text NameText { get; private set; }

            [field: SerializeField] public Image FactoryImage { get; private set; }

            [field: SerializeField] public TMP_Text LevelText { get; private set; }

            [field: SerializeField] public TMP_Text MiningRateText { get; private set; }

            [field: SerializeField] public TMP_Text PriceText { get; private set; }

            [field: SerializeField] public TMP_Text RequiredTimeText { get; private set; }

            [field: SerializeField] public Button BuyButton { get; private set; }

            [field: SerializeField] public Button CloseButton { get; private set; }
        }

        public FactoryUpgradeView()
        {

        }
        void IStartable.Start()
        {
            ButtonsSubscribe();
            TextSubscribe();
        }

        private void ButtonsSubscribe()
        {
            Scope.View.CloseButton.OnClickAsObservable().Subscribe(_ => Scope.CloseView()).AddTo(Scope);
        }

        private void TextSubscribe()
        {

        }
    }
}