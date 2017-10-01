﻿namespace BlueNebula.Common.Helpers
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using BlueNebula.Common.DTOs;

    /// <summary>
    /// The summary list builder
    /// </summary>
    /// <typeparam name="T">The entity type of the source list</typeparam>
    /// <typeparam name="T1">The result type of the summary list</typeparam>
    public class SummaryListBuilder<T, T1> : ISummaryListBuilder<T, T1>
    {
        private const int DEFAULT_PAGE_INDEX = 0;
        private const int DEFAULT_PAGE_SIZE = 20;

        /// <summary>
        /// Builds the summary list
        /// </summary>
        /// <param name="source">The source queryable</param>
        /// <param name="filter">filter object</param>
        /// <returns>The summary list result</returns>
        public async Task<SummaryList<T1>> BuildAsync(IQueryable<T> source, FilterRequestBase filter)
        {
            if (source == null)
            {
                throw new ArgumentException(nameof(source));
            }

            // paging
            var pageNumber = (filter?.PageIndex).IsNullOrZero() ? DEFAULT_PAGE_INDEX : filter.PageIndex;
            var pageSize = (filter?.PageSize).IsNullOrZero() ? DEFAULT_PAGE_SIZE : filter.PageSize;

            var totalRecords = await source.CountAsync();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            var items = source
                .Page(pageNumber, pageSize)
                .ProjectTo<T1>();

            return new SummaryList<T1>()
            {
                TotalPages = totalPages,
                PageIndex = pageNumber,
                Items = items,
            };
        }
    }
}
