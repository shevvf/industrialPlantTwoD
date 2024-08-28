using IndustrialPlant.LifetimeScopes.Extensions;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;
using IndustrialPlant.UI.Items;
using IndustrialPlant.UI.Items.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace IndustrialPlant.UI.MVVM.Switchable.Tasks
{
    public class SwitchableTasksView : VCObject<SwitchableTasksScope>, IEntryPoint
    {
        [Serializable]
        public class View
        {
            [field: SerializeField] public List<TaskView> Task { get; set; }
        }

        private readonly SwitchableTasksViewModel switchableTasksViewModel;

        public SwitchableTasksView(SwitchableTasksViewModel switchableTasksViewModel)
        {
            this.switchableTasksViewModel = switchableTasksViewModel;
        }

        void IStartable.Start()
        {
            ButtonsSubscribe();
            TextSubscribe();
        }

        private void ButtonsSubscribe()
        {

        }

        private void TextSubscribe()
        {

        }
    }
}