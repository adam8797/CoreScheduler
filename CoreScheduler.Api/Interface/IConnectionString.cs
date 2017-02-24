namespace CoreScheduler.Api
{
    /// <summary>
    /// Defines a generic connection string
    /// </summary>
    public interface IConnectionString
    {
        string Value { get; }
        ConnectionStringType ServerType { get; }
    }
}