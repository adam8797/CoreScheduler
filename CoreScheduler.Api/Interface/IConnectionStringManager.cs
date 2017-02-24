using System.Collections.Generic;

namespace CoreScheduler.Api
{
    /// <summary>
    /// Manages connection strings that are passed into the script
    /// </summary>
    public interface IConnectionStringManager
    {
        IConnectionString this[int index] { get; }
        IConnectionString this[string key] { get; }
        IEnumerable<IConnectionString> AsEnumerable();
        int Count();
        bool ContainsKey(string key);
        IConnectionString[] ForType(ConnectionStringType type);
    }
}