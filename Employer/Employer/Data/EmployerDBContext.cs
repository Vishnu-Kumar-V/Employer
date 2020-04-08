using Employer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employer.Data
{
    public class EmployerDBContext : DbContext
    {
        public EmployerDBContext() : base("DBConnectionString")
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}