using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    public class User
    {
        [Key]
        public int?  EmployeeId { get; set; }
        public string? Username { get; set; } 
        public string? Password { get; set; }
        public string? Role { get; set; } 
        public bool IsEnabled { get; set; } 
       
    }
}
