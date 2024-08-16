using IndustrialPlant.UI.MVVM.Base.Views;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Base.Controller
{
    public interface IViewController
    {
        void CloseView<TView>() where TView : IView;
        UniTask OpenViewAsync<TView>() where TView : Component, IView;
        UniTask SwitchViewAsync<TView>() where TView : Component, IView;
    }
}