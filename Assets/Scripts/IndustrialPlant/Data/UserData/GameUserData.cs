using System;
using System.Collections.Generic;

using IndustrialPlant.Data.StaticData;

namespace IndustrialPlant.Data.UserData
{
    [Serializable]
    public class GameUserData
    {
        public string quitTime;
        public string nextDailyReward;
        public List<FactoryStats> factoryStats;
    }
}