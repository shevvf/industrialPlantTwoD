using System;

using Cysharp.Threading.Tasks;

using R3;

namespace IndustrialPlant.Infrastructure.Services.DataService
{
    public interface IData : IDisposable
    {
        Observable<Unit> OnSave { get; }
        Observable<Unit> OnLoad { get; }
        Observable<Unit> OnRewrite { get; }

        UniTask SaveAsync();
        UniTask LoadAsync();
        UniTask RewriteAsync();
    }
}