using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace IndustrialPlant.UI.Items.Tasks
{
    [Serializable]
    public class TaskView
    {
        [field: SerializeField] public Image LockImage { get; private set; }
        [field: SerializeField] public Slider ProgressSlider { get; private set; }
        [field: SerializeField] public TMP_Text DescriptionText { get; private set; }
        [field: SerializeField] public Button ClaimRewardBtn { get; private set; }
    }
}