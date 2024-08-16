using IndustrialPlant.Infrastructure.AssetManagement.AssetsPath;
using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;
using IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.Infrastructure.StateMachine;

using Cysharp.Threading.Tasks;

namespace IndustrialPlant.App.StateMachine
{
    public class AppInitState : IState
    {
        private readonly IData data;
        private readonly IAssetProvider assetProvider;
        private readonly ISceneLoader sceneLoader;

        public AppInitState(IData data, IAssetProvider assetProvider, ISceneLoader sceneLoader)
        {
            this.data = data;
            this.assetProvider = assetProvider;
            this.sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await InizializeAsync();
            await sceneLoader.LoadAsync(ScenePath.GAME_SCENE_NAME);
        }

        public void Exit()
        {

        }

        private async UniTask InizializeAsync()
        {
            await data.LoadAsync();
            await assetProvider.InitializeAsync();
        }
    }
}