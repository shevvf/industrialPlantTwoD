using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace IndustrialPlant.UI.Items.IndustrialFactory
{
    [Serializable]
    public class IndustrialFactoryView
    {
        [field: SerializeField] public Button FactoryButton { get; set; }
        [field: SerializeField] public TMP_Text FactoryLevelText { get; set; }
    }
}