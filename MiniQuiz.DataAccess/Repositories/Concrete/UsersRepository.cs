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
    public class UsersRepository : IUsersRepository
    {
        private readonly MiniQuizDbContext dbContext;

        public UsersRepository(MiniQuizDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Users> Create(Users user)
        {
            dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Users> Get(int? userId)
        {
            var user = await dbContext.User.FindAsync(userId);

            if (user != null)
                return user;

            return null;
        }

        public async Task<Users> GetByEmail(string email)
        {
            var user = await dbContext.User
                .SingleOrDefaultAsync(x => x.Email == email);
            
            if (user != null)
                return user;

            return null;
        }
    }
}
