namespace CoreScheduler.Api
{
    /// <summary>
    /// Your job class(es) should implement this interface in order for CORE to find them.
    /// </summary>
    public interface IRunnable
    {
        void Main(IContext ctx);
    }
}