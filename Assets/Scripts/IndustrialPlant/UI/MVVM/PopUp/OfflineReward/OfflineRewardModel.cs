
using System.Numerics;

using IndustrialPlant.Data.UserData;

using R3;

namespace IndustrialPlant.UI.MVVM.PopUp.OfflineReward
{
    public class OfflineRewardModel
    {
        private readonly UserData userData;

        private ReactiveProperty<BigInteger> incomeOffline;
        private string timeOffline;

        public string TimeOffline
        {
            get
            {
                timeOffline ??= new(userData.GameUserData.quitTime);
                return timeOffline;
            }
        }

        public ReactiveProperty<BigInteger> IncomePerTap
        {
            get
            {
                incomeOffline ??= new(1);
                return incomeOffline;
            }
        }


        public OfflineRewardModel(UserData userData)
        {
            this.userData = userData;
        }
    }
}