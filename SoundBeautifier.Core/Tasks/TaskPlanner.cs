using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBeautifier.Core
{
    public class TaskPlanner
    {
        private readonly TaskFactory _taskFactory = new TaskFactory();
        /// <summary>
        /// Max count of tasks running at same time
        /// </summary>
        private readonly int _tasksMaximum = Environment.ProcessorCount;
        private List<Task> _runningTasks = new List<Task>();
        private readonly ITaskProvider _taskProvider;
        private readonly ITaskExecutor _taskExecutor;
        private readonly IUserNotifier _userNotifier;
        private bool _stoped;


        /// <summary>
        /// When task change state, we must notify about it
        /// </summary>
        public event EventHandler<TrackTask> TaskUpdated;

        public TaskPlanner(ITaskProvider taskProvider, ITaskExecutor taskExecutor, IUserNotifier userNotifier)
        {
            _taskProvider = taskProvider;
            _taskExecutor = taskExecutor;
            _userNotifier = userNotifier;
        }

        public void Stop()
        {
            _stoped = true;
        }

        public void Start()
        {
            _stoped = false;
            TrackTask trackTask = null;
            while (!_stoped)
            {
                trackTask = _taskProvider.GetPlannedTask();

                if (trackTask != null)
                {
                    //if we have enough resources to execute task
                    if (_runningTasks.Count() < _tasksMaximum || trackTask.Track.ServiceUser.Subscripe.Priority != Priority.Low)
                    {
                        _taskProvider.UpdateTaskStatus(trackTask.Id, TrackTaskStatus.Started);
                        TaskUpdated?.Invoke(this, trackTask);
                        //Async execute task
                        var executingTask = trackTask;
                        var task = _taskFactory.StartNew(async () =>
                        {
                            //Execute task
                            var status = await _taskExecutor.ExecuteTask(executingTask);
                            _taskProvider.UpdateTaskStatus(executingTask.Id, status);
                            _taskProvider.UpdateTargetContent(executingTask.Id, executingTask.Track.TargetContent);
                            //User must knows about his track
                            _userNotifier.NotifyUser(executingTask);
                            TaskUpdated?.Invoke(this, executingTask);
                        });
                        _runningTasks.Add(task);
                        task.ContinueWith((t) =>
                        {
                            _runningTasks.Remove(t);
                        });
                    }
                }
            }
        }

    }
}
