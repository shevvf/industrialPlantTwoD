using IndustrialPlant.Infrastructure.Factories.AddressableFactory;
using IndustrialPlant.Infrastructure.GameServices.ApplicationFocusService;
using IndustrialPlant.LifetimeScopes;

using VContainer.Unity;

namespace IndustrialPlant.Infrastructure.Factories.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly GameScope.MainGameFolder mainGameFolder;
        private readonly IAddressableFactory addressableFactory;
        private readonly IApplicationFocus applicationFocus;

        public GameFactory(GameScope.MainGameFolder mainGameFolder, IAddressableFactory addressableFactory, IApplicationFocus applicationFocus)
        {
            this.mainGameFolder = mainGameFolder;
            this.addressableFactory = addressableFactory;
            this.applicationFocus = applicationFocus;
        }

        void IStartable.Start()
        {
            applicationFocus.Initialize();
            CreateCanvas();
            CreateAudio();
        }

        public void CreateCanvas()
        {
            //addressableFactory.CreateByName(AddressablePath.GAME_CANVAS_PATH, mainGameFolder.CanvasHolder);
        }

        public void CreateAudio()
        {
            // addressableFactory.CreateByName(AddressablePath.GAME_AUDIO_PATH);
        }
    }
}