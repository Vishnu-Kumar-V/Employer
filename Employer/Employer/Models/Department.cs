using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employer.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        
        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}