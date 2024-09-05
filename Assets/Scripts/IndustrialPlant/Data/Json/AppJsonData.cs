using IndustrialPlant.Data.Path;
using Newtonsoft.Json.Linq;
using System;

namespace IndustrialPlant.Data.Json
{
    [Serializable]
    public class AppJsonData : JsonData<AppJsonData>
    {
        public JArray FactoriesData => Data[DataPath.FACTORIES_DATA][DataPath.FACTORIES_DATA_KEY] as JArray;
        public JArray TasksData => Data[DataPath.TASKS_DATA][DataPath.TASKS_DATA_KEY] as JArray;
        public JObject CurrencyData => Data[DataPath.USER_DATA][DataPath.CURRENCY_DATA_KEY] as JObject;
    }
}
