using AnimalSimulation.Data.Json;
using AnimalSimulation.Data.Path;
using IndustrialPlant.Data.StaticData;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.UI.Items.Currency;
using IndustrialPlant.UI.Items.Task;
using Newtonsoft.Json.Linq;
using R3;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using VContainer.Unity;

namespace IndustrialPlant.Infrastructure.Systems.SaveLoadSystem
{
    public class SaveLoadSystem : ISaveLoad
    {
        private readonly UserData userData;
        private readonly AppJsonData appJsonData;
        private readonly IData data;

        [DllImport("__Internal")]
        private static extern void saveProgress();

        [DllImport("__Internal")]
        private static extern void loadProgress();

        [DllImport("__Internal")]
        private static extern void rewriteProgress();

        public SaveLoadSystem(UserData userData, AppJsonData appJsonData, IData data)
        {
            this.userData = userData;
            this.appJsonData = appJsonData;
            this.data = data;
        }

        void IStartable.Start()
        {
            data.OnSave.Subscribe(_ => Save());
            data.OnLoad.Subscribe(_ => Load());
            data.OnRewrite.Subscribe(_ => Rewrite());
        }

        public async void Save()
        {
            if (Application.isEditor)
            {
                appJsonData.Data[DataPath.FACTORIES_DATA] = new JObject
                {
                    [DataPath.FACTORIES_DATA_KEY] = JArray.FromObject(userData.GameUserData.factoryStats)
                };

                appJsonData.Data[DataPath.USER_DATA] = JObject.FromObject(userData.GameUserData.currencyStats);

                await appJsonData.SaveData();
            }
            else
            {
                saveProgress();
            }
        }

        public async void Load()
        {
            if (Application.isEditor)
            {
                await appJsonData.LoadAllData(appJsonData.Jsons);

                userData.GameUserData.factoryStats = appJsonData.FactoriesData.ToObject<List<FactoryStats>>();
                userData.GameUserData.taskStats = appJsonData.TasksData.ToObject<List<TaskStats>>();
                userData.GameUserData.currencyStats = appJsonData.CurrencyData.ToObject<CurrencyStats>();
            }
            else
            {
                loadProgress();
            }
        }

        public async void Rewrite()
        {
            if (Application.isEditor)
            {
                await appJsonData.RewriteData();
            }
            else
            {
                rewriteProgress();
            }
        }
    }
}