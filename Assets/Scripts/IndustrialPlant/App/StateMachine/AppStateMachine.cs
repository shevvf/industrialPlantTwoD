using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;
using IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.Infrastructure.StateMachine;

namespace IndustrialPlant.App.StateMachine
{
    public class AppStateMachine : BaseStateMachine
    {
        public AppStateMachine(IData data, IAssetProvider assetProvider, ISceneLoader sceneLoader)
        {
            RegisterState(typeof(AppInitState), new AppInitState(data, assetProvider, sceneLoader));
        }
    }
}