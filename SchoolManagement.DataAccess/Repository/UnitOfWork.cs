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
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolManagementDbContext _db;

        public UnitOfWork(SchoolManagementDbContext db)
        {
            _db = db;
            admin = new Repository<Admin>(_db);
            stage=new StageRepository(_db);
            teacher=new TeacherRepository(_db);
            topic=new TopicRepository(_db);
            studenTopic = new StudentTopicRepository(_db);
            student = new StudentRepository(_db);


        }

        public IRepository<Admin> admin { get;private set; }

        public IStageRepository stage { get; private set; }

        public ITeacherRepository teacher { get; private set; }

        public ITopicRepository topic { get; private set; }

        public IStudentTopicRepository studenTopic { get; private set; }

        public IStudentRepository student { get; private set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
