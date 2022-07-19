using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{
    

    public interface ITopicRepository : IRepository<Topic>
    {
        Task<Topic> GetFully(int id);
        public  Task<IAsyncEnumerable<Topic>> GetAllFully();
        public Task<List<Topic>> GetAllFullyByTeacherId(int Id);
    }


}
