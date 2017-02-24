using System;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server
{
    public class JobTypeInfo
    {
        public JobTypeInfo(Type t)
        {
            JobType = t;
        }

        public Type JobType { get; set; }

        public Guid Guid
        {
            get { return JobType.GUID; }
        }

        public Type JobOptionsType
        {
            get
            {
                if (JobType.HasAttribute<JobOptionsTypeAttribute>())
                    return JobType.GetAttribute<JobOptionsTypeAttribute>().JobOptionsType;
                else
                    return typeof(JobOptions);
            }
        }

        public string Description
        {
            get
            {
                if (JobType.HasAttribute<JobDescriptionAttribute>())
                    return JobType.GetAttribute<JobDescriptionAttribute>().Value;
                return "";
            }
        }

        public string Name
        {
            get
            {
                if (JobType.HasAttribute<JobNameAttribute>())
                    return JobType.GetAttribute<JobNameAttribute>().Value;
                return JobType.FullName;
            }
        }

        public string Category
        {
            get
            {
                if (JobType.HasAttribute<JobCategoryAttribute>())
                    return JobType.GetAttribute<JobCategoryAttribute>().Value;
                return "";
            }
        }

        public string SourceFileExtension
        {
            get
            {
                if (JobType.HasAttribute<FileExtensionAttribute>())
                    return JobType.GetAttribute<FileExtensionAttribute>().Value;
                return ".txt";
            }
        }

        public string IconFileExtension
        {
            get
            {
                if (JobType.HasAttribute<JobIconAttribute>())
                    return JobType.GetAttribute<JobIconAttribute>().Value;
                return SourceFileExtension;
            }
        }

        public string Styler
        {
            get
            {
                if (JobType.HasAttribute<ScintillaStylerAttribute>())
                    return JobType.GetAttribute<ScintillaStylerAttribute>().Name;
                return null;
            }
        }
        
    }
}