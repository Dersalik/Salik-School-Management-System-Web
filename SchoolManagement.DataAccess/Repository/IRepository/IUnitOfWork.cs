using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<Admin> admin { get;  }
        IStageRepository stage { get; }
        ITeacherRepository teacher { get; }
        ITopicRepository topic { get; }
        IStudentTopicRepository studenTopic { get; }
        IStudentRepository student { get; }

        Task Save();
    }
}
