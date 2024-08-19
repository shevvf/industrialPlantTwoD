using Cysharp.Threading.Tasks;

using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Base.Views
{
    public class TransitionView<TView, TViewModel> : View<TView, TViewModel>
         where TView : class, IEntryPoint
         where TViewModel : class
    {
        private const float ANIMATION_DURATION = 0.3f;

        public override async void OpenView()
        {
            base.OpenView();
            SetInitialPositionOffScreen();
            await AnimateViewIn();
        }

        public override async void CloseView()
        {
            await AnimateViewOut();
            base.CloseView();
        }

        public override void SwitchView()
        {

        }

        private void SetInitialPositionOffScreen()
        {
            if (gameObject.transform != null)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -Screen.height, gameObject.transform.position.z);
            }
        }

        private async UniTask AnimateViewIn()
        {
            LeanTween.moveY(gameObject, Screen.height / 2, ANIMATION_DURATION).setEase(LeanTweenType.easeInOutQuad);

            await UniTask.Delay((int)(ANIMATION_DURATION * 1000));
        }

        private async UniTask AnimateViewOut()
        {
            LeanTween.moveY(gameObject, -Screen.height, ANIMATION_DURATION).setEase(LeanTweenType.easeInOutQuad);

            await UniTask.Delay((int)(ANIMATION_DURATION * 1000));
        }
    }
}