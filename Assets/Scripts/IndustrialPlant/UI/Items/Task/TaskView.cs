using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IndustrialPlant.UI.Items.Tasks
{
    [Serializable]
    public class TaskView
    {
        [field: SerializeField] public Image LockTaskImage { get; private set; }
        [field: SerializeField] public TMP_Text TaskDescription { get; private set; }
        [field: SerializeField] public Button ClaimRewardBtn { get; private set; }
    }
}