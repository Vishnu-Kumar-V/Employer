using Employer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employer.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployerDBContext db = new EmployerDBContext();

        public IQueryable<Employee> Employees
        {
            get { return db.Employees; }
        }

        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public Employee Save(Employee employee)
        {
            if (employee.EmployeeId == 0)
            {
                db.Employees.Add(employee);
            }
            else
            {
                db.Entry(employee).State = EntityState.Modified;
            }
            db.SaveChanges();
            return employee;
        }
    }
}