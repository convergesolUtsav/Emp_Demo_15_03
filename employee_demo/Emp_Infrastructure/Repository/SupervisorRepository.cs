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
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly EmployeeDbContext _context;

        public SupervisorRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Supervisor supervisor)
        {
            await _context.Supervisors.AddAsync(supervisor);
            await _context.SaveChangesAsync();
            return supervisor.Id;
        }

        public async Task<bool> Delete(int id)
        {
            bool isDeleted;
            try
            {

                Supervisor supervisor = await _context.Supervisors.Where(x => x.Id == id).FirstOrDefaultAsync();
                supervisor.IsActive = false;
                _context.Supervisors.Update(supervisor);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch 
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public async Task<IEnumerable<Supervisor>> GetAll()
        {
            return await _context.Supervisors.ToListAsync();

        }

        public async Task<Supervisor> GetById(int id)
        {
            return await _context.Supervisors.FindAsync(id);
            
        }

        public int Update(Supervisor supervisor)
        {
            _context.Entry(supervisor).State = EntityState.Modified;
            _context.Supervisors.Update(supervisor);
            _context.SaveChangesAsync();
            return supervisor.Id;
        }
    }
}
