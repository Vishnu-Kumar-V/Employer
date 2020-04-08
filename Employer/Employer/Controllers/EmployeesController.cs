using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employer.Data;
using Employer.Models;

namespace Employer.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository employeeRepository;
        private IDepartmentRepository departmentRepository;

        public EmployeesController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
        }

        // GET: Employees
        public ViewResult Index(string employeeName, string departmentId)
        {
            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName");

            var employees = employeeRepository.Employees.Include(e => e.Department);

            if (!string.IsNullOrEmpty(employeeName))
            {
                employees = employees.Where(e => e.EmployeeName.Contains(employeeName));
            }
            if (!string.IsNullOrEmpty(departmentId))
            {
                int tempDepartmentId = Convert.ToInt32(departmentId);
                employees = employees.Where(e => e.DepartmentId == tempDepartmentId);
            }
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.Employees.Include(e => e.Department).ToList().Find(e => e.EmployeeId == id);
            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName");
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,CreatedDate,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.CreatedDate = DateTime.Now;
                employeeRepository.Employees.Append(employee);
                employeeRepository.Save(employee);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,CreatedDate,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //employeeRepository.Entry(employee).State = EntityState.Modified;
                employeeRepository.Save(employee);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.Employees.Include(e => e.Department).ToList().Find(e => e.EmployeeId == id);
            ViewBag.DepartmentId = new SelectList(departmentRepository.Departments, "DepartmentId", "DepartmentName");
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = employeeRepository.Employees.FirstOrDefault(e => e.EmployeeId == id);
            employeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
