using System;

namespace CoreScheduler.Client.Desktop.Utilities
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class EditorForJobTypeAttribute : Attribute
    {
        public Type JobType { get; private set; }

        public EditorForJobTypeAttribute(Type jobType)
        {
            JobType = jobType;
        }
    }
}
