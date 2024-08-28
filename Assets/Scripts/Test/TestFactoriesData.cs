using IndustrialPlant;
using IndustrialPlant.UI.Items.IndustrialFactory;
using UnityEngine;
using VContainer;

namespace Test
{
    public class TestFactoriesData : MonoBehaviour
    {
        [Inject] private readonly IndustrialPlantModel IndustrialPlantModel;

        private void Start()
        {
            foreach (var factoryModel in IndustrialPlantModel.IndustrialFactoryModels)
            {
                Debug.Log($"Factory ID: {factoryModel.FactoryId.Value}");
                Debug.Log($"Factory Name: {factoryModel.FactoryName.Value}");
                Debug.Log($"Factory Level: {factoryModel.FactoryLevel.Value}");
                Debug.Log($"Factory Max Level: {factoryModel.FactoryMaxLevel.Value}");
                Debug.Log($"Factory Price: {factoryModel.FactoryPrice.Value}");
                Debug.Log($"Factory Mining Rate: {factoryModel.FactoryMiningRate.Value}");
                Debug.Log($"Factory Reward: {factoryModel.FactoryReward.Value}");
                Debug.Log($"Factory Required Time (sec): {factoryModel.FactoryRequiredTimeSec.Value}");
            }
        }
    }
}