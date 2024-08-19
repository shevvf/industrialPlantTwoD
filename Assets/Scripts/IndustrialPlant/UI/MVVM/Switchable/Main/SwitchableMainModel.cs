using System.Linq;

using IndustrialPlant.Data.UserData;

using ObservableCollections;

using R3;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainModel
    {
        private readonly UserData userData;

        private ObservableDictionary<int, int> factoriesLevel;
        private ReactiveProperty<int> currentFactoryId;

        // private readonly Subject<int> onCurrentFactoryId = new();
        // public Observable<int> OnCurrentFactoryId => onCurrentFactoryId;

        public ObservableDictionary<int, int> FactoriesLevel
        {
            get
            {
                factoriesLevel ??= new(
                    userData.GameUserData.factoryStats.ToDictionary(
                        factory => factory.id,
                        factory => factory.currentLevel
                    )
                );
                return factoriesLevel;
            }
        }

        public ReactiveProperty<int> CurrentFactoryId
        {
            get
            {
                currentFactoryId ??= new();
                // onCurrentFactoryId.OnNext(currentFactoryId.Value);
                return currentFactoryId;
            }
        }

        public SwitchableMainModel(UserData userData)
        {
            this.userData = userData;
        }
    }
}