using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace HR_Management_System
{
    public class AttendanceManagement
    {
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public string? AttendanceEntry  { get; set; }
        public string?  LeaveRequest  { get; set; }
       

    }



    //public class AttendanceEntry
    //{
        
    //    public DateTime Date { get; set; }
    //    public string Status { get; set; }
    //}

    //public class LeaveRequest
    //{
       
    //    public string EmployeeId { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //    public string Reason { get; set; }
    //}

}
