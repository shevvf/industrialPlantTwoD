using Cysharp.Threading.Tasks;

using IndustrialPlant.Audio;
using IndustrialPlant.Data.StaticData.Configs.Audio;
using IndustrialPlant.Infrastructure.AssetManagement.AssetsPath;
using IndustrialPlant.Infrastructure.AssetManagement.AssetsProvider;

using UnityEngine;

namespace IndustrialPlant.Infrastructure.GlobalServices.AudioService
{
    public class AudioService : IAudio
    {
        private readonly AudioFolder audioFolder;
        private readonly IAssetProvider assetProvider;

        public AudioService(AudioFolder audioFolder, IAssetProvider assetProvider)
        {
            this.audioFolder = audioFolder;
            this.assetProvider = assetProvider;
        }

        public async UniTask InitializeAsync()
        {
            await assetProvider.WarmupAssetsByLabel(AddressableLabels.SOUNDS_LABLE);
        }

        public void PlayMainSound(SoundClip soundClip, float volume = 0f)
        {
            audioFolder.MainSource.loop = true;
            PlaySound(audioFolder.MainSource, soundClip, volume);
        }

        public void PlayUISound(SoundClip soundClip, float volume = 0f)
        {
            PlaySound(audioFolder.UISource, soundClip, volume);
        }

        private void PlaySound(AudioSource audioSource, SoundClip sound, float volume)
        {
            audioSource.clip = sound.AudioClip;
            audioSource.volume = volume == 0 ? sound.Volume : volume;
            audioSource.Play();
        }
    }
}