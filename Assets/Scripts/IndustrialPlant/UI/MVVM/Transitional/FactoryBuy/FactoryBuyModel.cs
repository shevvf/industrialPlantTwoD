using IndustrialPlant.Data.StaticData;
using IndustrialPlant.Data.UserData;
using IndustrialPlant.UI.Items.IndustrialFactory;
using IndustrialPlant.UI.MVVM.Switchable.Main;

using R3;

using UnityEngine;

namespace IndustrialPlant.UI.MVVM.Transitional.FactoryBuy
{
    public class FactoryBuyModel
    {
        private readonly IndustrialPlantModel industrialPlantModel;
        private readonly SwitchableMainModel switchableMainModel;
        private ReactiveProperty<IndustrialFactoryModel> currentFactory = new();

        public ReactiveProperty<IndustrialFactoryModel> CurrentFactory
        {
            get => currentFactory;
        } 
  
        public FactoryBuyModel(IndustrialPlantModel industrialPlantModel,SwitchableMainModel switchableMainModel)
        {
            this.industrialPlantModel = industrialPlantModel;
            this.switchableMainModel = switchableMainModel;

            SubscribeFactory();
        }

        private void SubscribeFactory()
        {
            switchableMainModel.ClickedFactoryId
               .Subscribe(id =>
               {
                   currentFactory.OnNext(industrialPlantModel.IndustrialFactoryModels[id]);
               });
        }
    }
}