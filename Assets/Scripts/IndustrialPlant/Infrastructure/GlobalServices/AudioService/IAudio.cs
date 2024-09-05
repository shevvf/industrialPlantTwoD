using Cysharp.Threading.Tasks;

using IndustrialPlant.Data.StaticData.Configs.Audio;

namespace IndustrialPlant.Infrastructure.GlobalServices.AudioService
{
    public interface IAudio
    {
        UniTask InitializeAsync();
        void PlayUISound(SoundClip soundClip, float volume = 0f);
        void PlayMainSound(SoundClip soundClip, float volume = 0f);
    }
}