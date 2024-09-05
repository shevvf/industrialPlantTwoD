using System;
using System.Threading;

using IndustrialPlant.Infrastructure.GlobalServices.WebRequestService;
using IndustrialPlant.Infrastructure.GlobalServices.WebRequestService.ApiResponse;

using Cysharp.Threading.Tasks;

using Framework.Extensions;

using UnityEngine;

namespace IndustrialPlant.Infrastructure.GameServices.TimeService
{
    public class TimeService : ITime
    {
        private readonly IWebRequest webRequest;

        public TimeService(IWebRequest webRequest)
        {
            this.webRequest = webRequest;
        }

        public async UniTask<DateTime> RequestWorldServerTime()
        {
            try
            {
                string responseJson = await webRequest.GetAsync(WebRequestSettings.WORLD_TIME_API_URL, new CancellationToken());
                WorldTimeApiResponse worldTime = JsonExtensions.FromJson<WorldTimeApiResponse>(responseJson);
                if (!DateTime.TryParse(worldTime.datetime, out DateTime serverTime))
                {
                    throw new Exception("Failed to parse server time.");
                }

                return serverTime;
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching server time: " + ex.Message);
                throw;
            }
        }
    }
}