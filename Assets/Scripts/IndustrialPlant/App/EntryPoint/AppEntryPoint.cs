
using IndustrialPlant.App.StateMachine;

using VContainer.Unity;

namespace IndustrialPlant.App.EntryPoint
{
    public class AppEntryPoint : IEntryPoint
    {
        private readonly AppStateMachine appStateMachine;

        public AppEntryPoint(AppStateMachine appStateMachine)
        {
            this.appStateMachine = appStateMachine;
        }

        void IStartable.Start()
        {
            appStateMachine.Enter<AppInitState>();
        }
    }
}