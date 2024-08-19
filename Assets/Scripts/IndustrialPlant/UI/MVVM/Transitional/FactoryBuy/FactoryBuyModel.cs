using IndustrialPlant.Data.UserData;
using IndustrialPlant.UI.MVVM.Switchable.Main;

using R3;

using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyModel
    {
        private readonly UserData userData;
        private readonly SwitchableMainModel switchableMainModel;

        private ReactiveProperty<int> currentFactoryId = new();
        private ReactiveProperty<int> currentFactoryPrice;
        private ReactiveProperty<int> currentFactoryMiningRate;
        private ReactiveProperty<int> currentFactoryReward;
        private ReactiveProperty<int> currentFactoryRequiredTimeSec;
        private ReactiveProperty<string> currentFactoryName;

        public ReactiveProperty<int> CurrentFactoryId
        {
            get
            {
                currentFactoryId ??= new(switchableMainModel.CurrentFactoryId.Value);
                return currentFactoryId;
            }
        }

        public ReactiveProperty<int> CurrentFactoryPrice
        {
            get
            {
                currentFactoryPrice ??= new(userData.GameUserData.factoryStats[currentFactoryId.Value].basePrice);
                return currentFactoryPrice;
            }
        }

        public ReactiveProperty<int> CurrentFactoryMiningRate
        {
            get
            {
                currentFactoryMiningRate ??= new(userData.GameUserData.factoryStats[currentFactoryId.Value].baseMiningRate);
                return currentFactoryMiningRate;
            }
        }

        public ReactiveProperty<int> CurrentFactoryReward
        {
            get
            {
                currentFactoryReward ??= new(userData.GameUserData.factoryStats[currentFactoryId.Value].reward);
                return currentFactoryReward;
            }
        }

        public ReactiveProperty<int> CurrentFactoryRequiredTimeSec
        {
            get
            {
                currentFactoryRequiredTimeSec ??= new(userData.GameUserData.factoryStats[currentFactoryId.Value].baseRequiredTimeSec);
                return currentFactoryRequiredTimeSec;
            }
        }

        public ReactiveProperty<string> CurrentFactoryName
        {
            get
            {
                currentFactoryName ??= new(userData.GameUserData.factoryStats[currentFactoryId.Value].name);
                return currentFactoryName;
            }
        }

        public FactoryBuyModel(UserData userData, SwitchableMainModel switchableMainModel)
        {
            this.userData = userData;
            this.switchableMainModel = switchableMainModel;
            Debug.Log("FactoryBuyModel");
        }
    }
}