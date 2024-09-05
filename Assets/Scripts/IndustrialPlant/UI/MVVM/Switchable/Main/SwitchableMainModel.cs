using System.Linq;

using IndustrialPlant.Data.UserData;
using IndustrialPlant.UI.Items.IndustrialFactory;

using ObservableCollections;

using R3;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainModel
    {
        private readonly IndustrialPlantModel industrialPlantModel;

        private ObservableDictionary<int, int> factoriesLevel;
        private ReactiveProperty<int> clickedFactoryId;

        public ObservableDictionary<int, int> FactoriesLevel
        {
            get => factoriesLevel ??= new(
                   industrialPlantModel.IndustrialFactoryModels.ToDictionary(
                     factory => factory.FactoryId.Value,
                     factory => factory.FactoryLevel.Value
                   )
            );
        }

        public ReactiveProperty<int> ClickedFactoryId
        {
            get => clickedFactoryId ??= new();
        }

        public SwitchableMainModel(IndustrialPlantModel industrialPlantModel)
        {
             this.industrialPlantModel = industrialPlantModel;
        }
    }
}