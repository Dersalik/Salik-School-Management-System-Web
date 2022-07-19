using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Data
{
    public class SchoolManagementDbContext: DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options):base(options)
        {
         
        }

    //    public SchoolManagementDbContext() { }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Stage> stages { get; set; }   
        public DbSet<Student> students { get; set; }
        public DbSet<Topic> topics { get; set; }
        public DbSet<StudentTopic> studentTopics { get; set; }
        public DbSet<Teacher> teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTopic>()
                .HasKey(bc => new { bc.StudentId, bc.TopicId });
            modelBuilder.Entity<StudentTopic>()
                .HasOne(bc => bc.student)
                .WithMany(bc => bc.topics)
                .HasForeignKey(bc => bc.StudentId );
            modelBuilder.Entity<StudentTopic>()
                .HasOne(bc => bc.topic)
                .WithMany(c => c.students)
                .HasForeignKey(bc => bc.TopicId)
                .OnDelete(DeleteBehavior.Restrict);

            


        }
    }
}
