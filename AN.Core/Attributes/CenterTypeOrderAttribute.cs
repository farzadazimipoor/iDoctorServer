using System;

namespace AN.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CenterTypeOrderAttribute : Attribute
    {
        public int Order { get; set; }
    }
}
