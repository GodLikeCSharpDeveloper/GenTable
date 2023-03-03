using System.Collections;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorStoreServAppV5.Repository.StoreLogic.OrderRepository
{
    public static class GenLinqExt
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");
            Expression body = parameter;
            foreach (var member in orderByProperty.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }
            var orderByExpression = Expression.Lambda(body, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, body.Type },
                  source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
            
        }
    }
}
