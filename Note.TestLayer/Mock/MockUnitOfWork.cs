using Moq;
using Note.DataLayer.Repositories.Interfaces;
using Note.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.TestLayer.Mock
{
    /// <summary>
    /// Unit of work instance meant for testing
    /// </summary>
    public class MockUnitOfWork : IUnitOfWork
    {
        public MockUnitOfWork() 
        { 

        }

        public IEmployeeRepository Employees { get; set; }

        public INotationRepository Notations { get; set; }

        /// <summary>
        /// Result to return when Complete() is called in the Handlers
        /// </summary>
        public int CompleteResult { get; set; }

        public int Complete()
        {
            return CompleteResult;
        }

        public void Dispose()
        {            
        }
    }
}
