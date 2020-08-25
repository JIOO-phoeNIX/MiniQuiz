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
    public class OptionsRepository : IOptionsRepository
    {
        private readonly MiniQuizDbContext dbContext;

        public OptionsRepository(MiniQuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Options>> Create(List<Options> options)
        {
            dbContext.Options.AddRange(options);
            await dbContext.SaveChangesAsync();
            return options;
        }

        public async Task<Options> Delete(int? optionId)
        {
            var optionToDelete = dbContext.Options.Find(optionId);
            if (optionToDelete != null)
            {
                dbContext.Options.Remove(optionToDelete);
                await dbContext.SaveChangesAsync();
            }
            return optionToDelete;
        }

        public async Task DeleteByQuestionId(int? questionId)
        {
            var options = dbContext.Options
                .Where(op => op.QuestionId == questionId);

            dbContext.Options.RemoveRange(options);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Options> Get(int? optionId)
        {
            var option = await dbContext.Options.FindAsync(optionId);

            if (option != null)
                return option;

            return null;
        }

        public List<Options> GetAll()
        {
            return dbContext.Options.ToList();
        }

        public List<Options> GetByQuestionId(int? questionId)
        {
            return dbContext.Options
                .Where(op => op.QuestionId == questionId)
                .ToList();
        }

        public List<Options> Update(List<Options> options)
        {            
            dbContext.Options.UpdateRange(options);          
             dbContext.SaveChanges();

            return options;
        }
    }
}
