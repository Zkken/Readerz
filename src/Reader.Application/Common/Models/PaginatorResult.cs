using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reader.Application.Common.Models
{
    public class PaginatorResult<TResult>
    {
        /// <summary>
        /// Private constructor called by the CreateAsync method.
        /// </summary>
        private PaginatorResult(
            List<TResult> data,
            int count,
            int pageIndex,
            int pageSize)
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        }

        #region Methods

        /// <summary>
        /// Pages a IQueryable source.
        /// </summary>
        /// <param name="source">An IQueryable source of generic
        /// type</param>
        /// <param name="pageIndex">Zero-based current page index
        /// (0 = first page)</param>
        /// <param name="pageSize">The actual size of each
        /// page</param>
        /// <returns>
        /// A object containing the paged result
        /// and all the relevant paging navigation info.
        /// </returns>
        public static async Task<PaginatorResult<TResult>> CreateAsync(
            IQueryable<TResult> source,
            int pageIndex,
            int pageSize)
        {
            var count = await source.CountAsync();
            
            source = source.Skip(pageIndex * pageSize).Take(pageSize);
            
            var data = await source.ToListAsync();
            
            return new PaginatorResult<TResult>(
                data,
                count,
                pageIndex,
                pageSize);
        }

        /// <summary>
        /// Pages a IQueryable source.
        /// </summary>
        /// <param name="source">An IQueryable source of generic type</param>
        /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
        /// <param name="pageSize">The actual size of each page</param>
        /// <param name="mapFunc">A mapping function that will map entity => dto objects</param>
        /// <typeparam name="TSource">A source entity object</typeparam>
        /// <returns>
        ///A object containing the paged result
        /// and all the relevant paging navigation info.
        /// </returns>
        public static async Task<PaginatorResult<TResult>> CreateAsyncWithMapping<TSource>(
            IQueryable<TSource> source,
            int pageIndex,
            int pageSize,
            Func<List<TSource>, List<TResult>> mapFunc)
        {
            var count = await source.CountAsync();
            
            source = source
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
            
            var data = await source
                .ToListAsync();
            
            return new PaginatorResult<TResult>(
                mapFunc(data),
                count,
                pageIndex,
                pageSize);
        }
 
        #endregion

        #region Properties

        /// <summary>
        /// The data result.
        /// </summary>
        public List<TResult> Data { get;  }

        /// <summary>
        /// Zero-based index of current page.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Number of items contained in each page.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Total items count
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Total pages count
        /// </summary>
        private int TotalPages { get; }

        /// <summary>
        /// TRUE if the current page has a previous page,
        /// FALSE otherwise.
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// TRUE if the current page has a next page, FALSE otherwise.
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;

        #endregion
    }
    
}