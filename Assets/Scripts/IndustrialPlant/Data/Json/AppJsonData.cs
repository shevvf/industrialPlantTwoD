using System;
using System.IO;

using AnimalSimulation.Data.Path;

using Newtonsoft.Json.Linq;

using UnityEditor;

using UnityEngine;

namespace AnimalSimulation.Data.Json
{
    [Serializable]
    public class AppJsonData : JsonData<AppJsonData>
    {
        public JArray FactoriesData => Data[DataPath.FACTORIES_DATA][DataPath.FACTORIES_DATA_KEY] as JArray;
        public JArray TasksData => Data[DataPath.TASKS_DATA][DataPath.TASKS_DATA_KEY] as JArray;
        public JObject CurrencyData => Data[DataPath.USER_DATA][DataPath.CURRENCY_DATA_KEY] as JObject;

        #region EditorOnly

#if UNITY_EDITOR
        [MenuItem("Data/Reset")]
        public static void ResetDataEditor()
        {
            string path = $"{Application.persistentDataPath}/Json";
            foreach (string directory in Directory.GetDirectories(path))
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (IOException)
                {
                    Directory.Delete(directory, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Directory.Delete(directory, true);
                }
            }
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }
#endif

        #endregion
    }
}
