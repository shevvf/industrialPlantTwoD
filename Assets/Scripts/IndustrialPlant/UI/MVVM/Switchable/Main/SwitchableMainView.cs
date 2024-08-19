using System;
using System.Collections.Generic;
using System.Linq;

using IndustrialPlant.IndustrialFactory;
using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;

using ObservableCollections;

using R3;

using TMPro;

using UnityEngine;

using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainView : VCObject<SwitchableMainScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public List<IndustrialFactoryView> IndustrialFactories { get; set; }
        }

        private readonly SwitchableMainViewModel switchableMainViewModel;

        public SwitchableMainView(SwitchableMainViewModel switchableMainViewModel)
        {
            this.switchableMainViewModel = switchableMainViewModel;
        }

        void IStartable.Start()
        {
            ButtonsSubscribe();
            TextsSubscribe();
        }

        private void ButtonsSubscribe()
        {
            Scope.View.IndustrialFactories
                 .Select((factory, index) => factory.FactoryButton
                 .OnClickAsObservable()
                 .Subscribe(_ => switchableMainViewModel.OnFactoryClick(index)))
                 .ToList()
                 .ForEach(subscription => subscription.AddTo(Scope));
        }

        private void TextsSubscribe()
        {
            for (int i = 0; i < Scope.View.IndustrialFactories.Count && i < switchableMainViewModel.FactoriesLevel.Count; i++)
            {
                UpdateFactoryText(i, switchableMainViewModel.FactoriesLevel[i]);
            }

            switchableMainViewModel.FactoriesLevel
                .ObserveReplace()
                .Subscribe(change =>
                {
                    if (change.NewValue.Key >= 0 && change.NewValue.Key < Scope.View.IndustrialFactories.Count)
                    {
                        UpdateFactoryText(change.NewValue.Key, change.NewValue.Value);
                    }
                })
                .AddTo(Scope);
        }

        private void UpdateFactoryText(int factoryIndex, int factoryLevel)
        {
            TMP_Text factoryText = Scope.View.IndustrialFactories[factoryIndex].FactoryLevelText;

            if (factoryLevel <= 0)
            {
                factoryText.gameObject.SetActive(false);
            }
            else
            {
                factoryText.text = factoryLevel.ToString();
                factoryText.gameObject.SetActive(true);
            }
        }
    }
}