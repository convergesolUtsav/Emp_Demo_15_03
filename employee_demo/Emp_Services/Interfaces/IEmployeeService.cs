using Emp_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task<int> Add(Employee employee);
        Task<int> Update(Employee employee);
        Task<bool> Delete(int id);
    }
}
