using System;

namespace AWRO.Helper.UIHelper.Attributes
{
    public class AwroGridDateTime:Attribute
    {
        public string Format { get; set; }
        public bool ShowTime { get; set; }
    }
}
