using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniQuiz.DataAccess.Models
{
    public class MiniQuizDbContext: IdentityDbContext
    {
        public MiniQuizDbContext(DbContextOptions<MiniQuizDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// The question table
        /// </summary>
        public DbSet<Questions> Questions { get; set; }

        /// <summary>
        /// This table stores the options to the questions
        /// </summary>
        public DbSet<Options> Options { get; set; }
        
        /// <summary>
        /// This table stores the Email of each User
        /// </summary>
        public DbSet<Users> User { get; set; }

        /// <summary>
        /// This table stores the details of each question i.e the option chosen for each question answered
        /// </summary>
        public DbSet<UserAnswers> UserAnswers { get; set; }
    }
}
