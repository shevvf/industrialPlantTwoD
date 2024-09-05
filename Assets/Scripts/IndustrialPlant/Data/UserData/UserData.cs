using System;

using UnityEngine;

namespace IndustrialPlant.Data.UserData
{
    [Serializable]
    public class UserData
    {
        [field: SerializeField] public GameUserData GameUserData { get; set; }
        public TelegramUserData TelegramUserData { get; set; }
    }
}