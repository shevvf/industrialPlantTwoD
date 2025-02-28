using IndustrialPlant.Data.Json;
using IndustrialPlant.Data.Path;
using IndustrialPlant.Data.StaticData;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.UI.Items.Currency;
using IndustrialPlant.UI.Items.Task;
using Newtonsoft.Json.Linq;
using R3;
using System;
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
        private readonly CurrencyModel currencyModel;
        private readonly IData data;

        [DllImport("__Internal")]
        private static extern void saveProgress();

        [DllImport("__Internal")]
        private static extern void loadProgress();

        [DllImport("__Internal")]
        private static extern void rewriteProgress();

        public SaveLoadSystem(UserData userData, AppJsonData appJsonData, CurrencyModel currencyModel, IData data)
        {
            this.userData = userData;
            this.appJsonData = appJsonData;
            this.currencyModel = currencyModel;
            this.data = data;
        }

        void IStartable.Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ => Save());
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

                appJsonData.Data[DataPath.USER_DATA][DataPath.CURRENCY_DATA_KEY] = JObject.FromObject(currencyModel.Data);

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