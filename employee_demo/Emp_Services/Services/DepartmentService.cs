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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task<int> Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public Task<bool> Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }

        public Task<IEnumerable<Department>> GetAll()
        {
           return _departmentRepository.GetAll();
        }

        public Task<Department> GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public Task<int> Update(Department department)
        {
            return _departmentRepository.Update(department);
        }
    }
}
