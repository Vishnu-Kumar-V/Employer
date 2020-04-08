using Employer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employer.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private EmployerDBContext db = new EmployerDBContext();

        public IQueryable<Department> Departments
        {
            get { return db.Departments; }
        }

        public void Delete(Department department)
        {
            db.Departments.Remove(department);
            db.SaveChanges();
        }

        public Department Save(Department department)
        {
            if (department.DepartmentId == 0)
            {
                db.Departments.Add(department);
            }
            else
            {
                db.Entry(department).State = EntityState.Modified;
            }
            db.SaveChanges();
            return department;
        }
    }
}