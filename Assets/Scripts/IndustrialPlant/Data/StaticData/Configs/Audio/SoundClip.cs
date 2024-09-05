using System;

using UnityEngine;

namespace IndustrialPlant.Data.StaticData.Configs.Audio
{
    [Serializable]
    public class SoundClip
    {
        [field: SerializeField] public AudioClip AudioClip { get; private set; }
        [field: SerializeField, Range(0, 1)] public float Volume { get; private set; } = 0.5f;
    }
}