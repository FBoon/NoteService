using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Models
{
    /// <summary>
    /// https://code-maze.com/paging-aspnet-core-webapi/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

        /// <summary>
        /// Give the total number of records, the requested pagenumber and pagesize
        /// </summary>
        /// <param name="count">total number of records</param>
        /// <param name="pageNumber">current page</param>
        /// <param name="pageSize">number of records on a page</param>
        public PagedList(int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
