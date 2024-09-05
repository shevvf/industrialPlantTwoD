using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService
{
    public class SceneLoaderService : ISceneLoader
    {
        public async UniTask LoadAsync(string sceneName)
        {
            await LoadSceneAsync(sceneName);
        }

        private async UniTask LoadSceneAsync(string sceneName)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

            await waitNextScene;
        }
    }
}