using System.Linq;
using System.Linq.Expressions;

namespace MicroFunds.Common.Utility
{
    public static class QueryHelper
    {
        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending
            , bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, propertyName);
            LambdaExpression sort = Expression.Lambda(property, param);
            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
        public static IOrderedQueryable<T> ExtendedOrderBy<T>(this IQueryable<T> source, string propertyName , bool anotherLevel)
        {
            return OrderingHelper(source, propertyName, false, anotherLevel);
        }
        public static IOrderedQueryable<T> ExtendedOrderByDescending<T>(this IQueryable<T> source, string propertyName, bool anotherLevel)
        {
            return OrderingHelper(source, propertyName, true, anotherLevel);
        }
    }
}