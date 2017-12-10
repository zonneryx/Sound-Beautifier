namespace SoundBeautifier.Core
{
    /// <summary>
    /// User notifier
    /// </summary>
    public interface IUserNotifier
    {
        void NotifyUser(TrackTask trackTask);
    }
}