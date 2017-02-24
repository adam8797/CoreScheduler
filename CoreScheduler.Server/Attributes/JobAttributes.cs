using System;

namespace CoreScheduler.Server.Attributes
{
    public class JobOptionsTypeAttribute : Attribute
    {
        public Type JobOptionsType { get; private set; }

        public JobOptionsTypeAttribute(Type t)
        {
            JobOptionsType = t;
        }
    }

    public class JobNameAttribute : StringAttribute
    {
        public JobNameAttribute(string str) : base(str)
        {}
    }

    public class JobDescriptionAttribute : StringAttribute
    {
        public JobDescriptionAttribute(string str) : base(str)
        {}
    }

    public class FileExtensionAttribute : StringAttribute
    {
        public FileExtensionAttribute(string str) : base(str)
        {}
    }

    public class JobCategoryAttribute : StringAttribute
    {
        public JobCategoryAttribute(string str) : base(str)
        {}
    }

    public class ScintillaStylerAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Assembly { get; private set; }

        public ScintillaStylerAttribute(string name)
        {
            Name = name;
        }

        public ScintillaStylerAttribute(string name, string asm)
        {
            Name = name;
            Assembly = asm;
        }
    }

    public class CommentStringAttribute : StringAttribute
    {
        public CommentStringAttribute(string str) : base(str)
        {}
    }

    public class JobIconAttribute : StringAttribute
    {
        public JobIconAttribute(string fileExtension) : base(fileExtension)
        {}
    }

    public abstract class StringAttribute : Attribute
    {
        public string Value { get; protected set; }

        protected StringAttribute(string str)
        {
            Value = str;
        }
    }

    public class NoEditorAttribute : Attribute
    {}

    public class AutoDiscoverAttribute : Attribute
    {}
}
