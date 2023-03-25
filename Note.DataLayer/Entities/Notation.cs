using Note.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.DataLayer.Entities
{
    [Table("Notations")]
    public class Notation
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public NoteStatus Status { get; set; }

        public string Message { get; set; }

        public Guid EmployeeId { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public Employee AssignedEmployee { get; set; }
    }
}
