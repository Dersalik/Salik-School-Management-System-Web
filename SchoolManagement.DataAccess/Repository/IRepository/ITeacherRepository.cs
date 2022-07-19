using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{

    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetFully(int id);
        public  Task<IAsyncEnumerable<Teacher>> GetAllFully();
    }
}
