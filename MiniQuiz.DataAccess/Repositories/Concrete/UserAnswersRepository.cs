using MiniQuiz.DataAccess.Models;
using MiniQuiz.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQuiz.DataAccess.Repositories.Concrete
{
    public class UserAnswersRepository : IUserAnswersRepository
    {
        private readonly MiniQuizDbContext dbContext;

        public UserAnswersRepository(MiniQuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserAnswers> Create(UserAnswers userAnswer)
        {
            dbContext.UserAnswers.Add(userAnswer);
            await dbContext.SaveChangesAsync();
            return userAnswer;
        }

        public async Task Delete(int? questionId)
        {
            var answersToDelete = dbContext.UserAnswers
                .Where(x => x.QuestionId == questionId)
                .ToList();

            dbContext.UserAnswers.RemoveRange(answersToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<UserAnswers> Get(int? userAnswerId)
        {
            var userAnswer = await dbContext.UserAnswers.FindAsync(userAnswerId);

            if (userAnswer != null)
                return userAnswer;

            return null;
        }        

        public List<UserAnswers> GetByUserId(int? userId)
        {
            return dbContext.UserAnswers
                .Where(x => x.UserId == userId)
                .ToList();
        }
    }
}
