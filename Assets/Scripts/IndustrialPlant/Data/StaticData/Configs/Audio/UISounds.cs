using UnityEngine;

namespace IndustrialPlant.Data.StaticData.Configs.Audio
{
    [CreateAssetMenu(fileName = nameof(UISoundsConfig), menuName = "StaticData/Audio/" + nameof(UISoundsConfig))]
    public class UISoundsConfig : ScriptableObject
    {
        [field: SerializeField] public SoundClip Button { get; private set; }
        [field: SerializeField] public SoundClip Buy { get; private set; }
        [field: SerializeField] public SoundClip Clear { get; private set; }
        [field: SerializeField] public SoundClip Fail { get; private set; }
        [field: SerializeField] public SoundClip Grow { get; private set; }
        [field: SerializeField] public SoundClip Sell { get; private set; }
        [field: SerializeField] public SoundClip Touch { get; private set; }
        [field: SerializeField] public SoundClip UpgradeOrUnlock { get; private set; }
    }
}