using System;

using IndustrialPlant.Infrastructure.GameServices.TimeService;

using R3;

using UnityEngine;

namespace IndustrialPlant.Infrastructure.GameServices.ApplicationFocusService
{
    public class ApplicationFocusService : IApplicationFocus
    {
        private readonly ITime time;

        private readonly CompositeDisposable disposable = new();

        public ApplicationFocusService(ITime time)
        {
            this.time = time;
        }

        public void Initialize()
        {
            OnApplicationGainedFocus();

            Observable.FromEvent<bool>(
                h => Application.focusChanged += h,
                h => Application.focusChanged -= h
            )
            .DistinctUntilChanged()
            .Subscribe(isFocused =>
            {
                if (isFocused)
                {
                    OnApplicationGainedFocus();
                }
                else
                {
                    OnApplicationLostFocus();
                }
            }).AddTo(disposable);
        }

        private async void OnApplicationGainedFocus()
        {
            Debug.Log("Application gained focus");
            DateTime currentTime = await time.RequestWorldServerTime();
            Debug.Log("Current Time " + currentTime);
        }

        private async void OnApplicationLostFocus()
        {
            Debug.Log("Application lost focus");
            DateTime exitTime = await time.RequestWorldServerTime();
            Debug.Log("Exit Time " + exitTime);
        }

        public void Dispose()
        {
            disposable?.Dispose();
        }
    }
}