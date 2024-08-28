using IndustrialPlant.Data.StaticData;
using IndustrialPlant.UI.Items.Currency;
using IndustrialPlant.UI.Items.Task;
using System;
using System.Collections.Generic;

namespace IndustrialPlant.Data.UserData
{
    [Serializable]
    public class GameUserData
    {
        public string quitTime;
        public string nextDailyReward;

        public CurrencyStats currencyStats;
        public List<TaskStats> taskStats;
        public List<FactoryStats> factoryStats;
    }
}