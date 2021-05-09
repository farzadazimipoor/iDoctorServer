using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AN.Core.Models
{
    public class QueryModel<T>
    {
        public List<Expression<Func<T, bool>>> Predicates { get; set; } = new List<Expression<Func<T, bool>>>();
        public List<Expression<Func<T, string>>> SearchStringFilterProperties { get; set; } = new List<Expression<Func<T, string>>>();
        public string SearchString { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; } = null;
        public bool IsOrderByDesc { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
