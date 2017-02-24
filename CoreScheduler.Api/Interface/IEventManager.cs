namespace CoreScheduler.Api
{
    /// <summary>
    /// Logs events directly to CORE
    /// </summary>
    public interface IEventManager
    {
        void Add(EventLevel level, string message);
        void Add(EventLevel level, string format, params object[] args);
    }
}