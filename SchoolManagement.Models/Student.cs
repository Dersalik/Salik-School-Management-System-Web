using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        [MinLength(20)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required]
        [Range(10, 15, ErrorMessage = "The age of the student must be between 10 and 15")]
        public int age { get; set; }
        [Required]
        public bool gender { get; set; }
        [Required]

        public DateTime birthday { get; set; }
        public List<StudentTopic>? topics { get; set; }
        
        public Stage? stage { get; set; }
        public int? StageId { get; set; }



    }
}
