using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class StudentTopic
    {

        public Student student { get; set; }
        public int StudentId { get; set; }
        public Topic? topic { get; set; }
        public int? TopicId { get; set; }

        public double grade { get; set; }
        public bool isPassedTopic { get; set; }
    }
}
