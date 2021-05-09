using System;

namespace AN.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CenterTypeIconAttribute : Attribute
    {
        public string Name { get; set; }      
    }   
}
