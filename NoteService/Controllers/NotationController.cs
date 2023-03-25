using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Note.LogicLayer.Handlers.Interfaces;
using Note.LogicLayer.Models;
using Note.LogicLayer.Models.Requests.Notation;

namespace Note.WebService.Controllers
{
    /// <summary>
    /// Entry point for CRUD actions of Notation
    /// 
    /// https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0
    /// </summary>
    [ApiController]
    [Route("Notation")]
    public class NotationController : ControllerBase
    {
        private readonly INotationHandler notationHandler;

        public NotationController(INotationHandler notationHandler) 
        {
            this.notationHandler = notationHandler;    
        }

        /// <summary>
        /// Get a list of notations
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Paginated result</returns>
        [HttpPost("List")]
        public ActionResult<PagedList<Notation>> List([FromBody]ListNotationRequest request)
        {
            var notations = this.notationHandler.GetNotations(request);

            var metadata = new
            {
                notations.TotalCount,
                notations.PageSize,
                notations.CurrentPage,
                notations.TotalPages,
                notations.HasNext,
                notations.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(notations);
        }

        /// <summary>
        /// Add a new Notation record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Guid of new record on succes. Null on failure</returns>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(AddNotationRequest request)
        {
            var newRecordId = this.notationHandler.AddNotation(request);
            if (newRecordId != null)
            {
                return Ok(newRecordId);
            }

            return BadRequest();
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="notation"></param>
        /// <returns>succes</returns>
        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(UpdateNotationRequest notation)
        {
            if (this.notationHandler.UpdateNotation(notation))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
