using System.Threading;

using Cysharp.Threading.Tasks;

namespace IndustrialPlant.Infrastructure.GlobalServices.WebRequestService
{
    public interface IWebRequest
    {
        UniTask<string> GetAsync(string url, CancellationToken token);
    }
}