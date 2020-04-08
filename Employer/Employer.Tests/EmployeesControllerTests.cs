using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Employer.Controllers;
using Employer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Employer.Tests
{
    [TestClass]
    public class EmployeesControllerTests
    {
        static Mock<IEmployeeRepository> mockEmployeesRepo;
        static Mock<IDepartmentRepository> mockDepartmentsRepo;

        [ClassInitialize]
        public static void BuildMockData(TestContext context)
        {
            mockEmployeesRepo = new Mock<IEmployeeRepository>();
            mockDepartmentsRepo = new Mock<IDepartmentRepository>();

            mockEmployeesRepo.Setup(e => e.Employees).Returns(new Employee[]
                {
                    new Employee{EmployeeId=1, EmployeeName="Andrew", CreatedDate=DateTime.Now, DepartmentId = 1 },
                    new Employee{EmployeeId=1, EmployeeName="Brent", CreatedDate=DateTime.Now, DepartmentId = 2 },
                    new Employee{EmployeeId=1, EmployeeName="Chris", CreatedDate=DateTime.Now, DepartmentId = 1 }
                }.AsQueryable());

            mockDepartmentsRepo.Setup(d => d.Departments).Returns(new Department[]
                {
                    new Department { DepartmentId = 1, DepartmentName = "Accounts"},
                    new Department { DepartmentId = 2, DepartmentName = "Front Office"}
                }.AsQueryable());
        }

        [TestMethod]
        public void Employees_Index_View_Contains_ListOfEmployees_Model()
        {
            // Arrange
            EmployeesController employeesController = new EmployeesController(mockEmployeesRepo.Object, mockDepartmentsRepo.Object);

            // Act
            var actual = (List<Employee>)employeesController.Index("", "").Model;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(List<Employee>));
        }
    }
}
