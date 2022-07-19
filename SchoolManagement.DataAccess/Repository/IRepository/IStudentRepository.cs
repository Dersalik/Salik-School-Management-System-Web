using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{
    public interface IStudentRepository :IRepository<Student>
    {
        Task<Student> GetFully(int id);
        public  Task<IAsyncEnumerable<Student>> GetAllFully();
    }
}
