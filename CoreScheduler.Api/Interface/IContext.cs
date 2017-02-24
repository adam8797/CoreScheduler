using System.Net.Mail;
using Common.Logging;

namespace CoreScheduler.Api
{
    /// <summary>
    /// Represents the object that will be passed from CORE to the running script.
    /// </summary>
    public interface IContext
    {
        ILog Log { get; }
        IEventManager Events { get; }
        ICredentialManager Credentials { get; }
        IConnectionStringManager ConnectionStrings { get; }
        SmtpClient SmtpClient { get; }
    }
}