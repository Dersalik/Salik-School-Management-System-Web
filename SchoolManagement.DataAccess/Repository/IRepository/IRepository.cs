using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        void Add(T entity);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAll();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void UpdateEntity(T entity);


    }
}
