using MiniQuiz.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniQuiz.DataAccess.Repositories.Abstract
{
    public interface IQuestionsRepository
    {
        /// <summary>
        /// Get all the Questions
        /// </summary>
        /// <returns>A list containing all the QUestions</returns>
        List<Questions> GetAll();

        /// <summary>
        /// Get a particular Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <returns>The Question</returns>
        Task<Questions> Get(int? questionId);

        /// <summary>
        /// Create a new Question
        /// </summary>
        /// <param name="question">The Question to create</param>
        /// <returns>The created Question</returns>
        Task<Questions> Create(Questions question);

        /// <summary>
        /// Delete a Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <returns>The deleted Question</returns>
        Task<Questions> Delete(int? questionId);

       /// <summary>
       /// Update the details of a Question
       /// </summary>
       /// <param name="question">The Question to update</param>
       /// <returns>The Updated Question</returns>
        Task<Questions> Update(Questions question);
    }
}
