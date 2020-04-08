using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employer.Models
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }

        Employee Save(Employee employee);

        void Delete(Employee employee);
    }
}
