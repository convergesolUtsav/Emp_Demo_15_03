using Emp_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> GetById(int id);
        Task<IEnumerable<Department>> GetAll();
        Task<int> Add(Department department);
        Task<int> Update(Department department);
        Task<bool> Delete(int id);
    }
}
