using System.Collections.Generic;

namespace CoreScheduler.Api
{
    /// <summary>
    /// Manages credentials that are passed into
    /// </summary>
    public interface ICredentialManager
    {
        ICredential this[int index] { get; }
        ICredential this[string key] { get; }
        int Count();
        bool ContainsKey(string key);
        IEnumerable<ICredential> AsEnumerable();
    }
}