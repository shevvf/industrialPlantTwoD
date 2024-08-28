using IndustrialPlant.Data.StaticData;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.Infrastructure.Factories.BaseFactory;
using IndustrialPlant.UI.MVVM.Switchable.Main;
using R3;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IndustrialPlant.UI.Items.IndustrialFactory
{ 
    public class IndustrialFactoryModel
    {
        private readonly FactoryStats factoryStats;

        private ReactiveProperty<int> factoryId;
        private ReactiveProperty<string> factoryName;
        private ReactiveProperty<int> factoryLevel;
        private ReactiveProperty<int> factoryMaxLevel;
        private ReactiveProperty<int> factoryPrice;
        private ReactiveProperty<int> factoryMiningRate;
        private ReactiveProperty<int> factoryReward;
        private ReactiveProperty<int> factoryRequiredTimeSec;

        public ReactiveProperty<int> FactoryId
        {
            get => factoryId ??= new(factoryStats.id);
        }

        public ReactiveProperty<string> FactoryName
        {
            get => factoryName ??= new(factoryStats.name);
        }

        public ReactiveProperty<int> FactoryLevel
        {
            get => factoryLevel ??= new(factoryStats.currentLevel);
        }

        public ReactiveProperty<int> FactoryMaxLevel
        {
            get => factoryMaxLevel ??= new(factoryStats.maxLevel);
        }

        public ReactiveProperty<int> FactoryPrice
        {
            get => factoryPrice ??= new(factoryStats.basePrice);
        }

        public ReactiveProperty<int> FactoryMiningRate
        {
            get => factoryMiningRate ??= new(factoryStats.baseMiningRate);
        }

        public ReactiveProperty<int> FactoryReward
        {
            get => factoryReward ??= new(factoryStats.reward);
        }

        public ReactiveProperty<int> FactoryRequiredTimeSec
        {
            get => factoryRequiredTimeSec ??= new(factoryStats.baseRequiredTimeSec);
        }

        public IndustrialFactoryModel(FactoryStats factoryStats)
        { 
           this.factoryStats = factoryStats;    
        }
    }
}