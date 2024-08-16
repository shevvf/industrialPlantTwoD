using Cysharp.Threading.Tasks;

namespace IndustrialPlant.Infrastructure.GlobalServices.SceneLoaderService
{
    public interface ISceneLoader
    {
        UniTask LoadAsync(string sceneName);
    }
}