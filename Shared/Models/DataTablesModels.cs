using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shared.Models
{
    public enum DataTablesOrderDir
    {
        ASC = 0,
        DESC = 1
    }

    public class DataTablesSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class DataTablesOrder
    {
        public int Column { get; set; }
        public DataTablesOrderDir Dir { get; set; }
    }

    public class DataTablesColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DataTablesSearch Search { get; set; }
    }

    public class DataTablesParameters
    {
        public int Draw { get; set; }
        public DataTablesColumn[] Columns { get; set; }
        public DataTablesOrder[] Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DataTablesSearch Search { get; set; }
        public string SortOrder { get; }
        public IEnumerable<string> AdditionalValues { get; set; }
        public string FiltersObject { get; set; }
    }

    public class DataTablesResult<T>
    {
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty(PropertyName = "recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty(PropertyName = "data")]
        public IEnumerable<T> Data { get; set; }
    }

    public class DataTablesPagedResults<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalSize { get; set; }
    }
}
