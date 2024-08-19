using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Cysharp.Threading.Tasks;

using Newtonsoft.Json.Linq;

using UnityEngine;

namespace AnimalSimulation.Data.Json
{
    [Serializable]
    public class JsonData<T> where T : JsonData<T>
    {
        [field: SerializeField] protected string Path { get; private set; } = "Json";
        [field: SerializeField] public List<TextAsset> Jsons { get; private set; }
        public Dictionary<string, JObject> Data { get; private set; }

        public async UniTask SaveData()
        {
            List<UniTask> saveTasks = Data.Select(async key =>
            {
                string filePath = $"{Application.persistentDataPath}/{Path}/{key.Key}.json";
                await File.WriteAllTextAsync(filePath, key.Value.ToString());
            }).ToList();

            await UniTask.WhenAll(saveTasks);
        }

        public async UniTask RewriteData()
        {
            await InitData();
            await LoadAllData(Jsons);
        }

        public async UniTask LoadAllData(List<TextAsset> linkedJsons)
        {
            if (linkedJsons == null || linkedJsons.Count == 0)
                return;

            string[] keys = linkedJsons.Select(json => json.name).ToArray();

            await LoadData(keys);
        }
        private async UniTask InitData()
        {
            string directoryPath = $"{Application.persistentDataPath}/{Path}";

            await UniTask.RunOnThreadPool(() => Directory.CreateDirectory(directoryPath));

            List<UniTask> writeTasks = Jsons.Select(async json =>
            {
                string key = json.name;
                string filePath = $"{directoryPath}/{key}.json";
                await File.WriteAllLinesAsync(filePath, new string[] { json.text });
            }).ToList();

            await UniTask.WhenAll(writeTasks);
        }

        private async UniTask LoadData(params string[] keys)
        {
            if (!Directory.Exists($"{Application.persistentDataPath}/{Path}"))
                await InitData();

            Data = new Dictionary<string, JObject>();
            List<UniTask> loadTasks = keys.Select(async key =>
            {
                string json = await File.ReadAllTextAsync($"{Application.persistentDataPath}/{Path}/{key}.json");
                if (!string.IsNullOrEmpty(json))
                {
                    Data[key] = JObject.Parse(json);
                }
            }).ToList();

            await UniTask.WhenAll(loadTasks);
        }

        public List<T> GetFactoryStats()
        {
            if (Data != null && Data.TryGetValue("FactoriesData", out JObject factoryData))
            {
                JArray factoryArray = factoryData["factories"] as JArray;
                return factoryArray.ToObject<List<T>>();
            }
            return new List<T>();
        }

    }
}