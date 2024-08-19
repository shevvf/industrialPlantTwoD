using System.Collections.Generic;
using System.Runtime.InteropServices;

using AnimalSimulation.Data.Json;
using AnimalSimulation.Data.Path;

using IndustrialPlant.Data.StaticData;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.Infrastructure.Services.DataService;

using Newtonsoft.Json.Linq;

using R3;

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
                //  appJsonData.Data[DataPath.FACTORIES_DATA] = JArray.FromObject();

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

                if (appJsonData.Data != null && appJsonData.Data.TryGetValue(DataPath.FACTORIES_DATA, out JObject factoryData))
                {
                    JArray factoryArray = factoryData[DataPath.FACTORIES_DATA_KEY] as JArray;
                    userData.GameUserData.factoryStats = factoryArray.ToObject<List<FactoryStats>>();
                }
                else
                {
                    Debug.LogError("Не удалось найти данные о фабриках");
                }
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