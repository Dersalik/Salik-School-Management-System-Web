using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SchoolManagementDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(SchoolManagementDbContext db)
        {
            _db = db;
            this.dbSet=_db.Set<T>();

        }
        public async void Add(T entity)
        {
           
           await dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = dbSet;
           
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            
            dbSet.RemoveRange(entity);
        }

        public void UpdateEntity(T entity)
        {
            
            _db.Update(entity);
        }
    }
}
