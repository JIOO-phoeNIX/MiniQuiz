using MiniQuiz.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniQuiz.DataAccess.Repositories.Abstract
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="user">The User to create</param>
        /// <returns>The created User</returns>
        Task<Users> Create(Users user);

        /// <summary>
        /// Get a particular User
        /// </summary>
        /// <param name="userId">The Id of the User</param>
        /// <returns>The User</returns>
        Task<Users> Get(int? userId);

        /// <summary>
        /// Get a particular User
        /// </summary>
        /// <param name="email">The Email of the User</param>
        /// <returns>The User</returns>
        Task<Users> GetByEmail(string email);
    }
}
