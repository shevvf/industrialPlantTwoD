using Cysharp.Threading.Tasks;

namespace IndustrialPlant.Infrastructure.StateMachine.AppStateMachine
{
    public class AppGameState : IState
    {

        public AppGameState()
        {

        }

        public async void Enter()
        {
            await InizializeAsync();

        }

        public void Exit()
        {

        }

        private async UniTask InizializeAsync()
        {

        }
    }
}