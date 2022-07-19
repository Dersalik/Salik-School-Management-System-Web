using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository
{
    public class TeacherRepository: Repository<Teacher>, ITeacherRepository
    {

        private SchoolManagementDbContext _db;

        public TeacherRepository(SchoolManagementDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<Teacher> GetFully(int id)
        {
            return await _db.teachers
              .Include(s => s.topics)
              .SingleOrDefaultAsync(k => k.Id == id);

        }

        public async Task<IAsyncEnumerable<Teacher>> GetAllFully()
        {
            return  _db.teachers
              .Include(s => s.topics)
              .AsAsyncEnumerable();

        }
    }
}
