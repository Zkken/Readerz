using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using Readerz.Application.Common.Exceptions;

namespace Readerz.Application.Common.Helpers
{
    public static class Check
    {
        /// <summary>
        /// Check if entity exists by primary key value. If not throws a not found exception.
        /// </summary>
        /// <param name="source">IQueryable source.</param>
        /// <param name="primaryKey">Entity's primary key which represented as an expression.</param>
        /// <param name="id">Primary key's value.</param>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <typeparam name="TKey">Primary key type.</typeparam>
        public static async void TryEntityExistsAsync<TEntity, TKey>(this IQueryable<TEntity> source,
            Expression<Func<TEntity, TKey>> primaryKey, TKey id)
        {
            //e.x. input: prop.Id output: Id
            var pk = primaryKey.Body.ToString().Split('.').Last();
            var query = $"e => e.{pk} == {id}";
            var entity = await source.FirstOrDefaultAsync(query);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TEntity), id);
            }
        }
    }
}