using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Note.DataLayer.UnitOfWork;
using Note.LogicLayer.Enums;
using Note.LogicLayer.Handlers.Interfaces;
using Note.LogicLayer.Models;
using Note.LogicLayer.Models.Requests.Notation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.LogicLayer.Handlers
{
    /// <summary>
    /// Any business logic that needs to happen on Notations needs to happen here
    /// </summary>
    public class NotationHandler : INotationHandler
    {
        /// <summary>
        /// For accessing the database
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Convert between entities and models
        /// </summary>
        private readonly IMapper mapper;

        public NotationHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public Guid? AddNotation(AddNotationRequest notation)
        {
            var employee = this.unitOfWork.Employees.GetById(notation.EmployeeId);
            
            if (employee == null)
            {
                return null;
            }

            var newId = Guid.NewGuid();
            var dbNotation = new DataLayer.Entities.Notation()
            {
                Id = newId,
                Name = notation.Name,
                Number = notation.Number,
                Message = notation.Message,
                Status = (DataLayer.Enums.NoteStatus) notation.Status,
                EmployeeId = notation.EmployeeId,
            };

            this.unitOfWork.Notations.Add(dbNotation);

            var result = this.unitOfWork.Complete();
            
            if (result > 0)
            {
                return newId;
            }
            
            return null;
        }

        /// <inheritdoc/>
        public PagedList<Notation> GetNotations(ListNotationRequest request)
        {
            var notationQuery = this.unitOfWork.Notations
                .GetAll();

            if (request.StatusFilter.HasValue) 
            {
                notationQuery = notationQuery.Where(n => n.Status == (DataLayer.Enums.NoteStatus)request.StatusFilter.Value);
            }

            if (request.EmployeeFilter.HasValue) 
            {
                notationQuery = notationQuery.Where(n => n.EmployeeId == request.EmployeeFilter.Value);
            }

            var totalCount = notationQuery.Count();

            var dbNotations = notationQuery
                .Include(n => n.AssignedEmployee)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var result = new PagedList<Notation>(totalCount, request.PageNumber, request.PageSize);
            foreach (var dbNotation in dbNotations)
            {                
                result.Add(mapper.Map<Notation>(dbNotation));
            }

            return result;
        }

        /// <inheritdoc/>
        public bool UpdateNotation(UpdateNotationRequest notation)
        {
            var dbNotation = this.unitOfWork.Notations.GetById(notation.Id);

            var employee = this.unitOfWork.Employees.GetById(notation.EmployeeId);

            if (employee == null)
            {
                return false;
            }

            dbNotation.Status = (DataLayer.Enums.NoteStatus)notation.Status;
            dbNotation.EmployeeId = employee.Id;

            this.unitOfWork.Notations.Update(dbNotation);

            var result = this.unitOfWork.Complete();

            if (result == 1)
            {
                return true;
            }
            
            return false;
        }
    }
}
