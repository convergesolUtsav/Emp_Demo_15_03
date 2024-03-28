using Emp_Core;
using Emp_Infrastructure.Interfaces;
using Emp_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public  Task<int> Add(Employee employee)
        {
           return _employeeRepository.Add(employee);
        }

        public Task<bool> Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Task<Employee> GetById(int id)
        {
           return _employeeRepository.GetById(id);
        }

        public Task<int> Update(Employee employee)
        {
           return _employeeRepository.Update(employee);
        }
    }
}
