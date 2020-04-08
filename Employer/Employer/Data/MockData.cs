using Employer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employer.Data
{
    public class MockData
    {
        public static List<Department> getDepartments()
        {
            List<Department> departments = new List<Department>()
            {
                new Department()
                {
                    DepartmentName = "Information Technology",
                },
                new Department()
                {
                    DepartmentName = "Finance",
                }
            };

            return departments;
        }

        public static List<Employee> getEmployees(EmployerDBContext context)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeName = "Andy",
                    CreatedDate = DateTime.Now,
                    DepartmentId = context.Departments.Find(1).DepartmentId
                },
                new Employee()
                {
                    EmployeeName = "Bravo",
                    CreatedDate = DateTime.Now,
                    DepartmentId = context.Departments.Find(1).DepartmentId
                },
                new Employee()
                {
                    EmployeeName = "Charlie",
                    CreatedDate = DateTime.Now,
                    DepartmentId = context.Departments.Find(1).DepartmentId
                },
                new Employee()
                {
                    EmployeeName = "David",
                    CreatedDate = DateTime.Now,
                    DepartmentId = context.Departments.Find(2).DepartmentId
                },
                new Employee()
                {
                    EmployeeName = "Elf",
                    CreatedDate = DateTime.Now,
                    DepartmentId = context.Departments.Find(2).DepartmentId
                },
            };

            return employees;
        }
    }
}