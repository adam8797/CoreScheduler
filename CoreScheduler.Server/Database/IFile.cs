using System;

namespace CoreScheduler.Server.Database
{
    public interface IFile
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string TreeDirectory { get; set; }
    }
}