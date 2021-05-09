using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AN.Core.Data.Data
{
    public static class ExperssionHelper
    {
        public static Expression<Func<TFirstParam, TResult>> Compose<TFirstParam, TIntermediate, TResult>(this Expression<Func<TFirstParam, TIntermediate>> first, Expression<Func<TIntermediate, TResult>> second)
        {
            var param = Expression.Parameter(typeof(TFirstParam), "param");

            var newFirst = first.Body.Replace(first.Parameters[0], param);
            var newSecond = second.Body.Replace(second.Parameters[0], newFirst);

            return Expression.Lambda<Func<TFirstParam, TResult>>(newSecond, param);
        }

        public static Expression Replace(this Expression expression, Expression searchEx, Expression replaceEx)
        {
            return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
        }
    }

    internal class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression _from, _to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            _from = from;
            _to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == _from ? _to : base.Visit(node);
        }
    }

    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var secondBody = expr2.Body.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, secondBody), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var secondBody = expr2.Body.Replace(expr2.Parameters[0], expr1.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, secondBody), expr1.Parameters);
        }

        public static IQueryable<T> Match<T>(IQueryable<T> data, string searchTerm, IEnumerable<Expression<Func<T, string>>> filterProperties)
        {
            var predicates = filterProperties.Select(selector => selector.Compose(value => value != null && value.Contains(searchTerm)));
            var filter = predicates.Aggregate(False<T>(), (aggregate, next) => aggregate.Or(next));
            return data.Where(filter);
        }
    }

}
