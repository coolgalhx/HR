using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    public class PayrollManagement
    {
        [ForeignKey("EmployeeId")]

        public int? EmployeeId { get; set; }
        [Key]
        public int? PayrollId { get; set; }

       // [ForeignKey("Department")]
        public string? Department { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float? Salary { get; set; } 
        public float? Taxes { get; set; } 
        public float? Monthly { get; set; }
    }
}
