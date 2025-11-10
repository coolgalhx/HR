using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    public class Employee
    {
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public DateTime? DateOfBirth { get; set; } 
        public string? ContactInformation { get; set; } 
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? NationalInsurance { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; } 
        public string? EmploymentType { get; set; }



        
    }
}
