using IndustrialPlant.UI.Items.Currency;

namespace IndustrialPlant.UI.MVVM.MainHUD.MainHUD
{
    public class MainHUDModel
    {
        public readonly CurrencyModel currencyModel;

        public MainHUDModel(CurrencyModel currencyModel)
        {
            this.currencyModel = currencyModel;
        }
    }
}