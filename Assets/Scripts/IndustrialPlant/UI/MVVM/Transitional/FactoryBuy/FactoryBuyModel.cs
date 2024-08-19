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

        private ReactiveProperty<int> �urrentFactoryPrice = new();
        private ReactiveProperty<int> �urrentFactoryMiningRate = new();
        private ReactiveProperty<int> �urrentFactoryReward = new();
        private ReactiveProperty<int> �urrentFactoryRequiredTimeSec = new();
        private ReactiveProperty<string> �urrentFactoryName = new();

        public ReactiveProperty<int> CurrentFactoryPrice
        {
            get
            {
                return �urrentFactoryPrice;
            }
        }

        public ReactiveProperty<int> CurrentFactoryMiningRate
        {
            get
            {
                return �urrentFactoryMiningRate;
            }
        }

        public ReactiveProperty<int> CurrentFactoryReward
        {
            get
            {
                return �urrentFactoryReward;
            }
        }

        public ReactiveProperty<int> CurrentFactoryRequiredTimeSec
        {
            get
            {
                return �urrentFactoryRequiredTimeSec;
            }
        }

        public ReactiveProperty<string> CurrentFactoryName
        {
            get
            {
                return �urrentFactoryName;
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
            �urrentFactoryPrice.OnNext(factoryStats.basePrice);
            �urrentFactoryMiningRate.OnNext(factoryStats.baseMiningRate);
            �urrentFactoryReward.OnNext(factoryStats.reward);
            �urrentFactoryRequiredTimeSec.OnNext(factoryStats.baseRequiredTimeSec);
            �urrentFactoryName.OnNext(factoryStats.name);
        }
    }
}