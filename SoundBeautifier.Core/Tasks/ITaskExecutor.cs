using System.Threading.Tasks;

namespace SoundBeautifier.Core
{
    public interface ITaskExecutor
    {
        Task<TrackTaskStatus> ExecuteTask(TrackTask trackTask);
    }

}