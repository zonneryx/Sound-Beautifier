using System.Linq;
using System.Data.Entity;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// TrackTask provider from DataBase
    /// </summary>
    public class DbTaskProvider : ITaskProvider
    {

        /// <summary>
        /// Gets TrackTask for executing
        /// </summary>
        /// <returns></returns>
        public TrackTask GetPlannedTask()
        {
            using (var context = new SoundBeatifierDbContext())
                return context.TrackTasks
                    .Include(t => t.Track)
                    .Include(t => t.Track.ServiceUser)
                    .Include(t => t.Track.ServiceUser.Subscripe)
                    .FirstOrDefault(t => t.TrackTaskStatus == TrackTaskStatus.Planned);
        }

        /// <summary>
        /// Updates TrackTask
        /// </summary>
        public void UpdateTaskStatus(int taskId, TrackTaskStatus status)
        {
            using (var context = new SoundBeatifierDbContext())
            {
                context.TrackTasks.First(t => t.Id == taskId).TrackTaskStatus = status;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates Track TargetContent
        /// </summary>
        public void UpdateTargetContent(int taskId, byte[] targetContent)
        {
            using (var context = new SoundBeatifierDbContext())
            {
                context.TrackTasks
                       .Include(t=>t.Track)
                       .First(t => t.Id == taskId)
                       .Track
                       .TargetContent = targetContent;
                context.SaveChanges();
            }
        }

    }

}