using R3;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainViewModel
    {
        private readonly SwitchableMainModel switchableMainModel;

        private readonly CompositeDisposable disposable = new();

        public SwitchableMainViewModel(SwitchableMainModel switchableMainModel)
        {
            this.switchableMainModel = switchableMainModel;
        }


        public void OnSettingsClick()
        {

        }

        public void OnBoostClick()
        {

        }


    }
}