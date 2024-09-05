using R3;

namespace IndustrialPlant.UI.Items.Task
{
    public class TaskModel
    {
        private readonly TaskStats tasksStats;

        private ReactiveProperty<int> taskId;
        private ReactiveProperty<float> taskProgress;
        private ReactiveProperty<string> taskDescription;
        private ReactiveProperty<TaskConditions> taskCondition;

        public ReactiveProperty<int> TaskId
        {
            get => taskId ??= new(tasksStats.id);
        }

        public ReactiveProperty<float> TaskProgress
        {
            get => taskProgress ??= new(tasksStats.progress);
        }

        public ReactiveProperty<string> TaskDescription
        {
            get => taskDescription ??= new(tasksStats.description);
        }

        public ReactiveProperty<TaskConditions> TaskCondition
        {
            get => taskCondition ??= new(tasksStats.condition);
        }

        public TaskModel(TaskStats tasksStats)
        {
            this.tasksStats = tasksStats;
        }
    }
}