using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
