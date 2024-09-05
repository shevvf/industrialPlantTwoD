using Cysharp.Threading.Tasks;

using R3;

namespace IndustrialPlant.Infrastructure.Services.DataService
{
    public class DataService : IData
    {
        private readonly Subject<Unit> onSaveSubject = new();
        private readonly Subject<Unit> onLoadSubject = new();
        private readonly Subject<Unit> onRewriteSubject = new();

        public Observable<Unit> OnSave => onSaveSubject;
        public Observable<Unit> OnLoad => onLoadSubject;
        public Observable<Unit> OnRewrite => onRewriteSubject;

        public UniTask SaveAsync()
        {
            onSaveSubject.OnNext(Unit.Default);
            return UniTask.CompletedTask;
        }

        public UniTask LoadAsync()
        {
            onLoadSubject.OnNext(Unit.Default);
            return UniTask.CompletedTask;
        }

        public UniTask RewriteAsync()
        {
            onRewriteSubject.OnNext(Unit.Default);
            return UniTask.CompletedTask;
        }

        public void Dispose()
        {
            onSaveSubject.Dispose();
            onLoadSubject.Dispose();
            onRewriteSubject.Dispose();
        }
    }
}