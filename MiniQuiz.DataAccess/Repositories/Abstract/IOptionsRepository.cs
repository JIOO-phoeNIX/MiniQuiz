using MiniQuiz.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniQuiz.DataAccess.Repositories.Abstract
{
    public interface IOptionsRepository
    {
        /// <summary>
        /// Get all the Options in the database
        /// </summary>
        /// <returns>A list containing all the Options</returns>
        List<Options> GetAll();

        /// <summary>
        /// Get all the options for a Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <returns>A list containing all the Options of the Question</returns>
        List<Options> GetByQuestionId(int? questionId);

        /// <summary>
        /// Get a particular Option
        /// </summary>
        /// <param name="optionId">The Id of the Option</param>
        /// <returns>The Option</returns>
        Task<Options> Get(int? optionId);

        /// <summary>
        /// Create the Options of a Question
        /// </summary>
        /// <param name="options">A list containing the Options</param>
        /// <returns>The created Options</returns>
        Task<List<Options>> Create(List<Options> options);

        /// <summary>
        /// Delete the Options of a Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <returns></returns>
        Task DeleteByQuestionId(int? questionId);

        /// <summary>
        /// Delete an Option
        /// </summary>
        /// <param name="optionId">The Id of the Option</param>
        /// <returns>The deleted Option</returns>
        Task<Options> Delete(int? optionId);

        /// <summary>
        /// Update the details of the Options of a Question
        /// </summary>
        /// <param name="options">A list containing the Options to be updated</param>
        /// <returns>The updated Options</returns>
        List<Options> Update(List<Options> options);
    }
}
