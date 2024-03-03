using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Context;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly QuizAppContext _quizAppContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(QuizAppContext quizAppContext)
        {
           _quizAppContext = quizAppContext;
            _dbSet = quizAppContext.Set<TEntity>();

        }


        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _quizAppContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }   

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            _quizAppContext.SaveChanges();
        }

        public TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is not null ? _dbSet.Where(predicate) : _dbSet;
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            _quizAppContext.SaveChanges();
        }
    }
}
