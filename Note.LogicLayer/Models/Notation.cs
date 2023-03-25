using Note.LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Models
{
    public class Notation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public NoteStatus Status { get; set; }

        public string Message { get; set; }

        public Guid EmployeeId { get; set; }

        public Employee AssignedEmployee { get; set; }
    }
}