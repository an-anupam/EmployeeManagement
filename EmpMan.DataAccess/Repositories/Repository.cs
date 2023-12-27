using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
      //   private readonly IRepository<T> _repository;
       private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;


        public Repository(ApplicationDbContext db){
            _db = db;
            this.dbSet = _db.Set<T>();
            // this.dbSet = db.Set<T>();
        }

         public void Add(T entity){
            dbSet.Add(entity);
         }

         public T Get(Expression<Func<T, bool>> filter){
            IQueryable<T>? query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
         }

         public IEnumerable<T> GetAll()
         {
            IQueryable<T>? query = dbSet;
            return query.ToList();
         }

         public void Remove(T entity){
            dbSet.Remove(entity);
         }

         public void RemoveRange(IEnumerable<T> entity)
         {
            dbSet.RemoveRange(entity);
         }

    }
}