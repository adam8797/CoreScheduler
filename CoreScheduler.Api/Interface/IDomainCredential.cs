namespace CoreScheduler.Api
{
    /// <summary>
    /// A three part credential
    /// </summary>
    public interface IDomainCredential : ICredential
    {
        string Domain { get; }
    }
}