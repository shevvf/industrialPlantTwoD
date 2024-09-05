using System;

using IndustrialPlant.Data.WebAppData;

namespace IndustrialPlant.Data.UserData
{
    [Serializable]
    public class TelegramUserData
    {
        public WebAppInitData WebAppInitData { get; }
        public WebAppUser WebAppUser { get; }
        public WebAppChat WebAppChat { get; }
    }
}