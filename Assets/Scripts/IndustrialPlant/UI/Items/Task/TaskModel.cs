using IndustrialPlant.Data.UserData;
using IndustrialPlant.UI.Items.IndustrialFactory;
using R3;

namespace IndustrialPlant.UI.Items.Task
{
    public class TaskModel
    {       
        private readonly TaskStats tasksStats;

        private ReactiveProperty<int> taskId;
        private ReactiveProperty<float> taskProgress;
        private ReactiveProperty<TaskConditions> taskCondition;

        public ReactiveProperty<int> TaskId
        {
            get => taskId ??= new(tasksStats.taskId);
        }

        public ReactiveProperty<float> TaskProgress
        {
            get => taskProgress ??= new(tasksStats.taskProgress);
        }

        public ReactiveProperty<TaskConditions> TaskCondition
        {
            get => taskCondition ??= new(tasksStats.taskCondition);
        }

        public TaskModel(TaskStats tasksStats)
        {
            this.tasksStats = tasksStats;
        }
    }
}