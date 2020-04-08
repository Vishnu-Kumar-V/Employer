using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employer.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}