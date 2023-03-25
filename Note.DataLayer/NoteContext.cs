using Microsoft.EntityFrameworkCore;
using Note.DataLayer.Entities;

namespace Note.DataLayer
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {
        }

        public DbSet<Notation> Notations { get; set; }

        public DbSet<Employee> Employees { get; set; }  
    }
}