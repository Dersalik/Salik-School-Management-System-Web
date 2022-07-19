using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository
{
    public class StageRepository : Repository<Stage>, IStageRepository
    {

        private SchoolManagementDbContext _db;

        public StageRepository(SchoolManagementDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<Stage> GetFully(int? id)
        {
            return await _db.stages
              .Include(s=>s.topicList)
              .Include(s=>s.students)
              .SingleOrDefaultAsync(k => k.Id == id);

        }

        public async Task<IAsyncEnumerable<Stage>> GetAllFully()
        {
             return _db.stages
              .Include(s => s.topicList)
              .Include(s => s.students)
              . AsAsyncEnumerable();

        }

        public async Task<Stage> GetByStageNumber(Expression<Func<Stage, bool>> filter)
        {
            IQueryable<Stage> query = _db.stages.Include(k=>k.students)
               . Include(k => k.topicList).Where(filter);
            
            return await query.FirstOrDefaultAsync();
        }
    }
}
