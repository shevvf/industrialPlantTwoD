using System;

namespace IndustrialPlant.UI.Items.Task
{
    [Serializable]
    public class TaskStats
    {
        public int id;
        public float progress;
        public string description;
        public TaskConditions condition;
    }
}