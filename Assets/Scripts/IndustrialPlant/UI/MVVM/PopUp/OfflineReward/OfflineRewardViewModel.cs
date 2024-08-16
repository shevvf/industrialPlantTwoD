using IndustrialPlant.UI.MVVM.MainHUD;

namespace IndustrialPlant.UI.MVVM.PopUp.OfflineReward
{
    public class OfflineRewardViewModel
    {
        private readonly OfflineRewardModel offlineRewardModel;
        private readonly PopUpController popUpController;

        public OfflineRewardViewModel(OfflineRewardModel offlineRewardModel, PopUpController popUpController)
        {
            this.offlineRewardModel = offlineRewardModel;
            this.popUpController = popUpController;
        }

        public void OnClaimClick()
        {
            popUpController.CloseOfflineReward();
        }

        public void OnGambleClick()
        {
            popUpController.OpenGambleWheel();
        }
    }
}