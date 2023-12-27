using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmpMan.DataAccess.Repositories.Repository
{
    public interface IRepository<T> where T : class
    {
        // T - Employee, all modules

        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T>entity);
    }
}