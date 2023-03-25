using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.DataLayer.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string Username { get; set; }
    }
}
