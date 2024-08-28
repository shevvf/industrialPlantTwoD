using System;

namespace IndustrialPlant.UI.Items.Task
{
    [Serializable]
    public class TaskStats
    {
        public int taskId;
        public float taskProgress;
        public TaskConditions taskCondition;
    }
}