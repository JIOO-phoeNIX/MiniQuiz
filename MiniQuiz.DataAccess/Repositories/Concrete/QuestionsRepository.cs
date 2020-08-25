using Microsoft.EntityFrameworkCore;
using MiniQuiz.DataAccess.Models;
using MiniQuiz.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQuiz.DataAccess.Repositories.Concrete
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly MiniQuizDbContext dbContext;

        public QuestionsRepository(MiniQuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Questions> Create(Questions question)
        {
            dbContext.Questions.Add(question);
            await dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Questions> Delete(int? questionId)
        {
            var questionToDelete = dbContext.Questions.Find(questionId);
            if (questionToDelete != null)
            {
                dbContext.Questions.Remove(questionToDelete);
                await dbContext.SaveChangesAsync();
            }
            return questionToDelete;
        }

        public async Task<Questions> Get(int? questionId)
        {
            var question = await dbContext.Questions.FindAsync(questionId);

            if (question != null)
                return question;

            return null;
        }

        public List<Questions> GetAll()
        {
            return dbContext.Questions.ToList();
        }

        public async Task<Questions> Update(Questions question)
        {
            var questionToUpdate = dbContext.Questions.Attach(question);
            questionToUpdate.State = EntityState.Modified;

            await dbContext.SaveChangesAsync();

            return question;
        }
    }
}
