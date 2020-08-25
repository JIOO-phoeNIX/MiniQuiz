using MiniQuiz.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniQuiz.DataAccess.Repositories.Abstract
{
    public interface IUserAnswersRepository
    {
        /// <summary>
        /// Create a UserAnswer when a User answers a Question and submit
        /// </summary>
        /// <param name="userAnswer">The UserAnswer</param>
        /// <returns>The created UserAnswer</returns>
        Task<UserAnswers> Create(UserAnswers userAnswer);

        /// <summary>
        /// Get all the UserAnswers for a User
        /// </summary>
        /// <param name="userId">The Id of the User</param>
        /// <returns>A list containing all the UserAnswers</returns>
        List<UserAnswers> GetByUserId(int? userId);

        /// <summary>
        /// Get a UserAnswer
        /// </summary>
        /// <param name="userAnswerId">The Id of the UserAnswer</param>
        /// <returns>The UserAnswer</returns>
        Task<UserAnswers> Get(int? userAnswerId);

        /// <summary>
        /// Delete all the UserAnswers for a Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <returns></returns>
        Task Delete(int? questionId);
    }
}
