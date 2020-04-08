using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employer.Models
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }

        Department Save(Department department);

        void Delete(Department department);
    }
}
