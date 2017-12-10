namespace SoundBeautifier.Core
{
    /// <summary>
    /// TrackTask provider
    /// </summary>
    public interface ITaskProvider
    {
        /// <summary>
        /// Gets TrackTask for executing
        /// </summary>
        /// <returns></returns>
        TrackTask GetPlannedTask();

        /// <summary>
        /// Updates TrackTask
        /// </summary>
        void UpdateTaskStatus(int taskId, TrackTaskStatus status);
        /// <summary>
        /// Updates Track TargetContent
        /// </summary>
        void UpdateTargetContent(int id, byte[] targetContent);
    }

}