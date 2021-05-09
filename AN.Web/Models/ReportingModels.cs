using System.Data;

namespace AN.Web.Models
{
    public class ReportParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class ReportDatasourceModel
    {
        public string Name { get; set; }
        public DataTable Value { get; set; }
    }
}
