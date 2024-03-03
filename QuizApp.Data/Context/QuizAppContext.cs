using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Context
{
    public class QuizAppContext : DbContext
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizEntity>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<QuestionEntity>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
        public DbSet<QuizEntity> Quizzes => Set<QuizEntity>();



    }
}
