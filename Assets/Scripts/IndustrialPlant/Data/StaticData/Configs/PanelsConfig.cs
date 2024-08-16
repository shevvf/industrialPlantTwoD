using System.Collections.Generic;

using UnityEngine;

using VContainer.Unity;

namespace IndustrialPlant.Data.StaticData.Configs
{
    public class PanelsConfig : ScriptableObject
    {
        [field: SerializeField] public List<AssetReferenceValuePair> Assets { get; private set; }

#if UNITY_EDITOR    
        void OnValidate()
        {
            SetTypes();
        }

        [ContextMenu("Set Types")]
        public void SetTypes()
        {
            foreach (var item in Assets)
            {
                if (item.Asset == null)
                    return;

                LifetimeScope view = item.Asset.editorAsset.GetComponent<LifetimeScope>();
                item.MonoBehaviour = view;
                // Debug.Log($"{item.Asset.editorAsset} + {item.MonoBehaviour}");
            }
        }
#endif
    }
}