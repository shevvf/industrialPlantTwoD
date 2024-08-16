using System.Runtime.InteropServices;

using IndustrialPlant.Data.UserData;
using IndustrialPlant.Infrastructure.Services.DataService;

using R3;

using UnityEngine;

using VContainer.Unity;

namespace IndustrialPlant.Infrastructure.Systems.SaveLoadSystem
{
    public class SaveLoadSystem : ISaveLoad
    {
        private readonly UserData userData;
        private readonly IData data;

        [DllImport("__Internal")]
        private static extern void saveProgress();

        [DllImport("__Internal")]
        private static extern void loadProgress();

        [DllImport("__Internal")]
        private static extern void rewriteProgress();

        public SaveLoadSystem(UserData userData, IData data)
        {
            this.userData = userData;
            this.data = data;
        }

        void IStartable.Start()
        {
            data.OnSave.Subscribe(_ => Save());
            data.OnLoad.Subscribe(_ => Load());
            data.OnRewrite.Subscribe(_ => Rewrite());
        }

        public void Save()
        {
            if (Application.isEditor)
            {

            }
            else
            {
                saveProgress();
            }
        }

        public void Load()
        {
            if (Application.isEditor)
            {
                userData.GameUserData.quitTime = "1:0:0";
            }
            else
            {
                loadProgress();
            }
        }

        public void Rewrite()
        {
            if (Application.isEditor)
            {

            }
            else
            {
                rewriteProgress();
            }
        }
    }
}