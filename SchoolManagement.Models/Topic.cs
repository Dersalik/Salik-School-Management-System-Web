using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }
        public List<StudentTopic>? students { get; set; }
        public Stage? Stage { get; set; }
        public int? StageId { get; set; }
        public Teacher? teacher { get; set; }

    }
}
