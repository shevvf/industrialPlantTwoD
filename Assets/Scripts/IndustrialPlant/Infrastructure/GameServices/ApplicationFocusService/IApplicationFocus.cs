using System;

namespace IndustrialPlant.Infrastructure.GameServices.ApplicationFocusService
{
    public interface IApplicationFocus : IDisposable
    {
        void Initialize();
    }
}