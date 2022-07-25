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
    public class StudentTopicRepository : Repository<StudentTopic>, IStudentTopicRepository
    {
        private SchoolManagementDbContext _db;

        public StudentTopicRepository(SchoolManagementDbContext db) : base(db)
        {
            this._db = db;
        }

        public IEnumerable<StudentTopic> GetAllWitStudentById(int id)
        {
            var d = _db.studentTopics
                .Include(d => d.student)
                .Where(d=>d.TopicId==id);
                

        
                return d;
        }

        public async Task<StudentTopic> GetFully(int sid,int tid)
        {
            var res= await _db.studentTopics
                .SingleOrDefaultAsync(k => k.TopicId == tid && k.StudentId == sid);
            return res;
        }
    }
}
