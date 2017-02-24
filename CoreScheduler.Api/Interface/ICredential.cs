namespace CoreScheduler.Api
{
    /// <summary>
    /// A standard credential
    /// </summary>
    public interface ICredential
    {
        string Username { get; }
        string Password { get; }
    }
}