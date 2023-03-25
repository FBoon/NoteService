using Note.LogicLayer.Models;
using Note.LogicLayer.Models.Requests.Notation;

namespace Note.LogicLayer.Handlers.Interfaces
{
    /// <summary>
    /// Notation handler, handles the business layer / logic for notations
    /// </summary>
    public interface INotationHandler
    {
        /// <summary>
        /// Add new Notation
        /// </summary>
        /// <param name="notation"></param>
        /// <returns>Guid of new record. Null on failure</returns>
        public Guid? AddNotation(AddNotationRequest notation);

        /// <summary>
        /// Update the notation status or assigned employee
        /// </summary>
        /// <param name="notation"></param>
        /// <returns>succes</returns>
        public bool UpdateNotation(UpdateNotationRequest notation);

        /// <summary>
        /// Get a paged list of notations
        /// can be filtered by
        ///  - employee
        ///  - status
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PagedList<Notation> GetNotations(ListNotationRequest request);
    }
}
