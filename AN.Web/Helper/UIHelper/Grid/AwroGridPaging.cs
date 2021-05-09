using System.Collections.Generic;

namespace AWRO.Helper.UIHelper.Grid
{
    public class AwroGridPaging
    {
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public Dictionary<string,object> Parameters { get; set; }
        public string FilterParameters { get; set; } 
    }
}
