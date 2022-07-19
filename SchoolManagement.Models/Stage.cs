using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Stage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Stage Number")]
        [Range(1,6)]
        public int StageNumber { get; set; }
        public List<Student>? students { get; set; }
        public List<Topic>? topicList { set; get; }


    }
}
