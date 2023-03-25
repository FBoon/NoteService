using AutoMapper;
using Moq;
using Note.DataLayer;
using Note.DataLayer.UnitOfWork;
using Note.LogicLayer.Mapper;
using Note.TestLayer.Mock;
using AutoMapper;
using System.Reflection;
using Note.LogicLayer.Handlers;
using Note.LogicLayer.Models.Requests.Notation;
using Note.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using Note.DataLayer.Repositories.Interfaces;

namespace Note.TestLayer
{
    [TestClass]
    public class NotationsTest
    {
        /// <summary>
        /// Test user 1
        /// </summary>
        private Employee Henk;

        /// <summary>
        /// Test user 2
        /// </summary>
        private Employee Tinie;

        /// <summary>
        /// Id of Notation in the mock repository
        /// </summary>
        private Guid NotationId;

        /// <summary>
        /// Notation returned by mock unitofwork
        /// </summary>
        private Notation Notation;

        private MockUnitOfWork MockUnitOfWork;

        /// <summary>
        /// Initiate and get the test data
        /// </summary>
        /// <returns></returns>
        private List<Notation> GetTestData()
        {
            Henk = new Employee()
            {
                Id = Guid.NewGuid(),
                Username = "Henk"
            };

            Tinie = new Employee()
            {
                Id = Guid.NewGuid(),
                Username = "Tinie"
            };

            var notation1 = new Notation() { Id = Guid.NewGuid(), AssignedEmployee = Henk, EmployeeId = Henk.Id, Name = "name", Message = "Message", Number = "0612345678", Status = DataLayer.Enums.NoteStatus.New };
            var notation2 = new Notation() { Id = Guid.NewGuid(), AssignedEmployee = Henk, EmployeeId = Henk.Id, Name = "name", Message = "Message", Number = "0612345678", Status = DataLayer.Enums.NoteStatus.New };
            var notation3 = new Notation() { Id = Guid.NewGuid(), AssignedEmployee = Tinie, EmployeeId = Tinie.Id, Name = "name", Message = "Message", Number = "0612345678", Status = DataLayer.Enums.NoteStatus.New };
            var notation4 = new Notation() { Id = Guid.NewGuid(), AssignedEmployee = Tinie, EmployeeId = Tinie.Id, Name = "name", Message = "Message", Number = "0612345678", Status = DataLayer.Enums.NoteStatus.New };
            
            var notationList = new List<Notation>();

            NotationId = notation1.Id;
            Notation = notation1;

            notationList.Add(notation1);
            notationList.Add(notation2);
            notationList.Add(notation3);
            notationList.Add(notation4);

            return notationList;
        }

        /// <summary>
        /// Get the notation handler with a mock unit of work, loaded with test data
        /// </summary>
        /// <returns></returns>
        private NotationHandler GetNotationHandler()
        {
            MockUnitOfWork = new MockUnitOfWork();
            
            var notationList = GetTestData();

            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            mockEmployeeRepo.Setup(x => x.GetById(Henk.Id)).Returns(Henk);
            mockEmployeeRepo.Setup(x => x.GetById(Tinie.Id)).Returns(Tinie);

            MockUnitOfWork.Employees = mockEmployeeRepo.Object;

            var mockNotationsRepo = new Mock<INotationRepository>();
            mockNotationsRepo.Setup(x => x.GetAll()).Returns(notationList.AsQueryable());
            mockNotationsRepo.Setup(x => x.Update(new Notation()));
            mockNotationsRepo.Setup(x => x.GetById(NotationId)).Returns(Notation);
            MockUnitOfWork.Notations = mockNotationsRepo.Object;

            var mapper = GetMapper();
            var notationHandler = new NotationHandler(MockUnitOfWork, mapper);

            return notationHandler;
        }

        /// <summary>
        /// Get mapper
        /// </summary>
        /// <returns></returns>
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(typeof(MapperConfig));
            });                     

            return config.CreateMapper();
        }

        [TestMethod]
        public void GetNotationsTest()
        {
            var notationHandler = GetNotationHandler();
            
            var notationRequest = new ListNotationRequest();
            notationRequest.PageSize = 2;
            notationRequest.PageNumber = 1;

            var notations = notationHandler.GetNotations(notationRequest);

            Assert.IsNotNull(notations);
            Assert.AreEqual(2, notations.Count());      // Notations returned
            Assert.AreEqual(4, notations.TotalCount);   // Total notations in mock db
        }

        [TestMethod]
        public void AddNotationsTest()
        {
            var notationHandler = GetNotationHandler();
            MockUnitOfWork.CompleteResult = 1;

            var addNotationRequest = new AddNotationRequest();
            addNotationRequest.Status = LogicLayer.Enums.NoteStatus.New;
            addNotationRequest.Number = "0612345678";
            addNotationRequest.Name = "Willem";
            addNotationRequest.Message = "Verkeerd verbonden";

            var results = new List<ValidationResult>();
            Validator.TryValidateObject(addNotationRequest, new ValidationContext(addNotationRequest), results, true);

            var addNotationRequest2 = new AddNotationRequest();
            addNotationRequest2.Status = LogicLayer.Enums.NoteStatus.New;
            addNotationRequest2.Number = "06123456789";
            addNotationRequest2.Name = "Willem";
            addNotationRequest2.Message = "Verkeerd verbonden";
            addNotationRequest2.EmployeeId = Henk.Id;

            var results2 = new List<ValidationResult>();
            Validator.TryValidateObject(addNotationRequest2, new ValidationContext(addNotationRequest2), results2, true);

            var resultTrue = notationHandler.AddNotation(addNotationRequest2);

            Assert.AreEqual(0, results.Count);  // no validation errors
            Assert.AreEqual(1, results2.Count); // 1 validation error
            Assert.IsTrue(resultTrue.HasValue); // Guid result has a value
        }


        [TestMethod]
        public void UpdateNotationsTest()
        {
            var notationHandler = GetNotationHandler();
            MockUnitOfWork.CompleteResult = 1;

            var updateNotationRequest = new UpdateNotationRequest();
            updateNotationRequest.Status = LogicLayer.Enums.NoteStatus.Done;
            updateNotationRequest.EmployeeId = Tinie.Id;
            updateNotationRequest.Id = NotationId;

            var result = notationHandler.UpdateNotation(updateNotationRequest);

            Assert.IsTrue(result); // update succes
        }
    }
}