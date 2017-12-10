using System.Threading;
using System.Threading.Tasks;

namespace SoundBeautifier.Core
{
    public class TaskExecutor : ITaskExecutor
    {
        public async Task<TrackTaskStatus> ExecuteTask(TrackTask trackTask) {
            try {
                Thread.Sleep(10000);
                return TrackTaskStatus.Completed;
            }
            catch 
            {
                return TrackTaskStatus.ErrorDuringExecution;
            }
        }
    }

}