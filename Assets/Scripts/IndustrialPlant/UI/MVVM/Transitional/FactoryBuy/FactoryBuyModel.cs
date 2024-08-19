using IndustrialPlant.Data.StaticData;
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

        private int currentFactoryId;

        private ReactiveProperty<int> ñurrentFactoryPrice = new();
        private ReactiveProperty<int> ñurrentFactoryMiningRate = new();
        private ReactiveProperty<int> ñurrentFactoryReward = new();
        private ReactiveProperty<int> ñurrentFactoryRequiredTimeSec = new();
        private ReactiveProperty<string> ñurrentFactoryName = new();

        public ReactiveProperty<int> CurrentFactoryPrice
        {
            get
            {
                return ñurrentFactoryPrice;
            }
        }

        public ReactiveProperty<int> CurrentFactoryMiningRate
        {
            get
            {
                return ñurrentFactoryMiningRate;
            }
        }

        public ReactiveProperty<int> CurrentFactoryReward
        {
            get
            {
                return ñurrentFactoryReward;
            }
        }

        public ReactiveProperty<int> CurrentFactoryRequiredTimeSec
        {
            get
            {
                return ñurrentFactoryRequiredTimeSec;
            }
        }

        public ReactiveProperty<string> CurrentFactoryName
        {
            get
            {
                return ñurrentFactoryName;
            }
        }

        public FactoryBuyModel(UserData userData, SwitchableMainModel switchableMainModel)
        {
            this.userData = userData;
            this.switchableMainModel = switchableMainModel;

            SubscribeFactoryId();
        }

        private void SubscribeFactoryId()
        {
            switchableMainModel.CurrentFactoryId.Subscribe(id =>
            {
                Debug.Log($"Current Factory ID: {id}");
                currentFactoryId = id;
                SetFactoryData();
            });
        }

        private void SetFactoryData()
        {
            int factoryId = currentFactoryId;

            FactoryStats factoryStats = userData.GameUserData.factoryStats[factoryId];
            ñurrentFactoryPrice.OnNext(factoryStats.basePrice);
            ñurrentFactoryMiningRate.OnNext(factoryStats.baseMiningRate);
            ñurrentFactoryReward.OnNext(factoryStats.reward);
            ñurrentFactoryRequiredTimeSec.OnNext(factoryStats.baseRequiredTimeSec);
            ñurrentFactoryName.OnNext(factoryStats.name);
        }
    }
}