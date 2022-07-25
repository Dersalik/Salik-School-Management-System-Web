using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{
    public interface IStudentTopicRepository : IRepository<StudentTopic>
    {
        public IEnumerable<StudentTopic> GetAllWitStudentById(int id);
        public Task<StudentTopic> GetFully(int sid, int tid);


    }

   
}
