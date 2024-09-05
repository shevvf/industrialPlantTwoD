using System;

using Cysharp.Threading.Tasks;

namespace IndustrialPlant.Infrastructure.GameServices.TimeService
{
    public interface ITime
    {
        UniTask<DateTime> RequestWorldServerTime();
    }
}