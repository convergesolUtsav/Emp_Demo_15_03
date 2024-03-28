using Emp_Core;
using Emp_Infrastructure.context;
using Emp_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Emp_Infrastructure.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public DepartmentRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }   

        public async Task<int> Add(Department department)
        {
            await _employeeDbContext.Departments.AddAsync(department);
            await _employeeDbContext.SaveChangesAsync();
            return department.Id;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted;
            try
            {
                bool departmentReferenced = await _employeeDbContext.Employees
                    .AnyAsync(e => e.DepartmentID == id);

                if (departmentReferenced)
                {
                    isDeleted = false;
                }
                else
                {
                    Department department = await _employeeDbContext.Departments
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

                    if (department != null)
                    {
                        department.IsActive = false;
                        _employeeDbContext.Departments.Update(department);
                        await _employeeDbContext.SaveChangesAsync();
                        isDeleted = true;
                    }
                    else
                    {
                        isDeleted = false;
                    }
                }
            }
            catch
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var department = await _employeeDbContext.Departments.ToListAsync();
            return department;
        }

        public async Task<Department> GetById(int id)
        {
           return  await _employeeDbContext.Departments.FindAsync(id);
        }

        public async Task<int> Update(Department department)
        {
            _employeeDbContext.Entry(department).State = EntityState.Modified;
            _employeeDbContext.Departments.Update(department);
           await _employeeDbContext.SaveChangesAsync();
            return department.Id;
        }
    }
}
