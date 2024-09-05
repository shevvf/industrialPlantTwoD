using System;

using UnityEngine;

namespace IndustrialPlant.Audio
{
    [Serializable]
    public class AudioFolder
    {
        [field: SerializeField] public AudioListener AudioListener { get; private set; }
        [field: SerializeField] public AudioSource MainSource { get; private set; }
        [field: SerializeField] public AudioSource UISource { get; private set; }
    }
}