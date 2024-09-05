using System;
using System.Threading;

using Cysharp.Threading.Tasks;

using UnityEngine.Networking;

namespace IndustrialPlant.Infrastructure.GlobalServices.WebRequestService
{
    public class WebRequestService : IWebRequest
    {
        public async UniTask<string> GetAsync(string url, CancellationToken token)
        {
            using UnityWebRequest request = UnityWebRequest.Get(url);
            await request.SendWebRequest().WithCancellation(token);

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new Exception("WebRequest error: " + request.error);
            }

            return request.downloadHandler.text;
        }
    }
}