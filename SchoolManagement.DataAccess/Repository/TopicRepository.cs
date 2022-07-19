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
    public class TopicRepository: Repository<Topic>, ITopicRepository
    {

        private SchoolManagementDbContext _db;

        public TopicRepository(SchoolManagementDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<Topic> GetFully(int id)
        {
            return await _db.topics
              .Include(s => s.students)
              .Include(s=>s.Stage)
              .Include(s=>s.teacher)
              .SingleOrDefaultAsync(k => k.Id == id);

        }


        public async Task<IAsyncEnumerable<Topic>> GetAllFully()
        {

            return  _db.topics
                .Include(k=>k.students)
                .Include(k=>k.Stage)
                .Include(k=>k.teacher)
                .AsAsyncEnumerable();

        }

        public async Task<List<Topic>> GetAllFullyByTeacherId(int Id)
        {

            return _db.topics
                .Include(k => k.students)
                .Include(k => k.Stage)
                .Include(k => k.teacher)
                .Where(k => k.teacher.Id == Id)
                .ToListAsync().Result;
                

        }

    }
}
