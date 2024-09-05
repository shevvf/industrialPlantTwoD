using IndustrialPlant.UI.Items.IndustrialFactory;
using R3;
using ObservableCollections;
using IndustrialPlant.Data.UserData;
using System.Linq;
using IndustrialPlant.UI.Items.Task;
using Cysharp.Threading.Tasks;
using IndustrialPlant.UI.Items.Currency;
using System.Collections.Generic;

namespace IndustrialPlant
{
    public class IndustrialPlantModel
    {
        private readonly UserData userData;

        private List<IndustrialFactoryModel> industrialFactoryModels;
        private ObservableList<TaskModel> taskModels;

        public List<IndustrialFactoryModel> IndustrialFactoryModels
        {
            get => industrialFactoryModels ??= new(
                   userData.GameUserData.factoryStats.Select(factoryStats => new IndustrialFactoryModel(factoryStats)).ToList());
        }

        public ObservableList<TaskModel> TaskModels
        {
            get => taskModels ??= new(
                   userData.GameUserData.taskStats.Select(taskStats => new TaskModel(taskStats)).ToList());
        }

        public IndustrialPlantModel(UserData userData)
        {
            this.userData = userData;
        }
    }
}