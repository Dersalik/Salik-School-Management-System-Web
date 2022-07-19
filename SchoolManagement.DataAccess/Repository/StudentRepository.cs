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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private SchoolManagementDbContext _db;

        public StudentRepository(SchoolManagementDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<Student> GetFully(int id)
        {
              return await _db.students
                .Include(s=> s.topics)
                .Include(s => s.stage)
                .SingleOrDefaultAsync(k=>k.Id == id);

        }

        public async Task<IAsyncEnumerable<Student>> GetAllFully()
        {

            return  _db.students
                   .Include(s => s.topics)
                   .Include(s => s.stage)
                   .AsAsyncEnumerable();
          
             
        }

        





    }
}
