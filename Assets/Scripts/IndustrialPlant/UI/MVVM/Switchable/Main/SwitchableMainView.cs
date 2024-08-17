using System;
using System.Collections.Generic;

using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;

using UnityEngine;
using UnityEngine.UI;

using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainView : VCObject<SwitchableMainScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public List<Button> FactoriesButtons { get; set; }
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

        }

        private void TextsSubscribe()
        {

        }
    }
}