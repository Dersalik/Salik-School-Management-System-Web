using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{
    public interface IStageRepository : IRepository<Stage>
    {
        Task<Stage> GetFully(int? id);
        Task<Stage> GetByStageNumber(Expression<Func<Stage, bool>> filter);
        public Task<IAsyncEnumerable<Stage>> GetAllFully();

    }
}
