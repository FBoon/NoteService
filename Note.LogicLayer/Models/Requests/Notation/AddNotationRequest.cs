using Note.LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Models.Requests.Notation
{
    public class AddNotationRequest : IRequest
    {
        [StringLength(255, MinimumLength = 0)]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Number { get; set; }

        [Required]
        public NoteStatus Status { get; set; }

        public string Message { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
    }
}
