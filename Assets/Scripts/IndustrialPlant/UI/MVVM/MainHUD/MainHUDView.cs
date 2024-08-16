using System;

using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Main;

using R3;

using UnityEngine;
using UnityEngine.UI;

using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDView : VCObject<MainHUDScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public Button MainButton { get; private set; }
            [field: SerializeField] public Button UpgradeButton { get; private set; }
            [field: SerializeField] public Button FriendsButton { get; private set; }
            [field: SerializeField] public Button TasksButton { get; private set; }
            [field: SerializeField] public Button TonButton { get; private set; }
        }

        private readonly MainHUDViewModel mainHUDViewModel;

        public MainHUDView(MainHUDViewModel mainHUDViewModel)
        {
            this.mainHUDViewModel = mainHUDViewModel;
        }

        void IStartable.Start()
        {
            ButtonsSubscribe();
        }

        private void ButtonsSubscribe()
        {
            Scope.View.MainButton.OnClickAsObservable().Subscribe(_ => mainHUDViewModel.OnMainClick()).AddTo(Scope);
            Scope.View.UpgradeButton.OnClickAsObservable().Subscribe(_ => mainHUDViewModel.OnUpgradeClick()).AddTo(Scope);
            Scope.View.FriendsButton.OnClickAsObservable().Subscribe(_ => mainHUDViewModel.OnFriendsClick()).AddTo(Scope);
            Scope.View.TasksButton.OnClickAsObservable().Subscribe(_ => mainHUDViewModel.OnTasksClick()).AddTo(Scope);
            Scope.View.TonButton.OnClickAsObservable().Subscribe(_ => mainHUDViewModel.OnTonClick()).AddTo(Scope);
        }
    }
}