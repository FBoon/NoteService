using Note.LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Models.Requests.Notation
{
    public class UpdateNotationRequest : IRequest
    {
        [Required]
        public Guid Id { get; set; }

        public NoteStatus Status { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
