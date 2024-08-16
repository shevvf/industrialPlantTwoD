using System;

using UnityEngine;
using UnityEngine.AddressableAssets;

using VContainer.Unity;

namespace IndustrialPlant.Data.StaticData.Configs
{
    [Serializable]
    public class AssetReferenceValuePair
    {
        [field: SerializeField] public AssetReferenceGameObject Asset { get; private set; }

        [field: SerializeField] public LifetimeScope MonoBehaviour { get; set; }
    }
}