using Cysharp.Threading.Tasks;

using IndustrialPlant.Infrastructure.AssetManagement.AssetsPath;
using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;
using IndustrialPlant.Infrastructure.GlobalServices.AudioService;
using IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService;
using IndustrialPlant.Infrastructure.Services.DataService;
using IndustrialPlant.Infrastructure.StateMachine;

namespace IndustrialPlant.App.StateMachine
{
    public class AppInitState : IState
    {
        private readonly IData data;
        private readonly IAssetProvider assetProvider;
        private readonly ISceneLoader sceneLoader;
        private readonly IAudio audio;

        public AppInitState(IData data, IAssetProvider assetProvider, ISceneLoader sceneLoader, IAudio audio)
        {
            this.data = data;
            this.assetProvider = assetProvider;
            this.sceneLoader = sceneLoader;
            this.audio = audio;
        }

        public async void Enter()
        {
            await InitializeAsync();

            await sceneLoader.LoadAsync(ScenePath.GAME_SCENE_NAME);
        }

        public void Exit()
        {

        }

        private async UniTask InitializeAsync()
        {
            await data.LoadAsync();
            await assetProvider.InitializeAsync();
            await audio.InitializeAsync();
        }
    }
}