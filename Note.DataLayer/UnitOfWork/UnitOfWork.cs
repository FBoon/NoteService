using Note.DataLayer.Repositories;
using Note.DataLayer.Repositories.Interfaces;

namespace Note.DataLayer.UnitOfWork
{
    /// <summary>
    /// https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/#Unit_Of_Work_Pattern
    /// 
    /// This class is the entry-point for the database.
    /// Repositories are exposed through this class
    /// 
    /// When adding or updating records:
    /// Do as many Add and Update as possible before calling complete.
    /// This will ensure a single transaction and a single succes or failure
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NoteContext _context;

        public UnitOfWork(NoteContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Notations = new NotationRepository(_context);
        }

        public IEmployeeRepository Employees { get; private set; }

        public INotationRepository Notations { get; private set; }

        /// <summary>
        /// Call after updates / adds are done
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
