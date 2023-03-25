using Note.LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Models.Requests.Notation
{
    /// <summary>
    /// Request for notations that comes in through the Note.WebService
    /// </summary>
    public class ListNotationRequest : PagedRequest
    {
        /// <summary>
        /// Only show notations with this status
        /// </summary>
        public NoteStatus? StatusFilter { get; set; }

        /// <summary>
        /// Only show notations that are assigned to this employee
        /// </summary>
        public Guid? EmployeeFilter { get; set; }
    }
}
