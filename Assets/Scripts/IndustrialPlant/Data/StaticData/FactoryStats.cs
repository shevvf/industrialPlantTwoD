using System;

namespace IndustrialPlant.Data.StaticData
{
    [Serializable]
    public class FactoryStats
    {
        public int id;
        public string name;
        public int currentLevel;
        public int maxLevel;
        public int basePrice;
        public int baseMiningRate;
        public int reward;
        public int baseRequiredTimeSec;
    }
}