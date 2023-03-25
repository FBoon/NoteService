using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Models.Requests
{
    /// <summary>
    /// Inherit from this class when making adding paging
    /// 
    /// https://code-maze.com/paging-aspnet-core-webapi/
    /// </summary>
    public abstract class PagedRequest : IRequest
    {
        /// <summary>
        /// The requested page size
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; }

        /// <summary>
        /// The current page number, starting at 1
        /// </summary>
        public int PageNumber { get; set; }
    }
}
