using Note.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.DataLayer.UnitOfWork
{
    /// <summary>
    /// https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }

        INotationRepository Notations { get; }

        int Complete();
    }
}
