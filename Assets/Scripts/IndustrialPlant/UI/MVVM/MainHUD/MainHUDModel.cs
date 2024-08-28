using System.Numerics;

using IndustrialPlant.Data.UserData;
using IndustrialPlant.UI.Items.Currency;
using R3;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDModel
    {
        public CurrencyModel currencyModel;

        public MainHUDModel(CurrencyModel currencyModel)
        {
            this.currencyModel = currencyModel;
        }
    }
}