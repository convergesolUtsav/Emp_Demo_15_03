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
    public class SupervisorService : ISupervisorService
    {
        private readonly ISupervisorRepository _supervisorRepository ;

        public SupervisorService(ISupervisorRepository supervisorRepository)
        {
            _supervisorRepository = supervisorRepository;
        }

        public Task<int> Add(Supervisor supervisor)
        {
           return _supervisorRepository.Add(supervisor);
        }

        public Task<bool> Delete(int id)
        {
            return _supervisorRepository.Delete(id);
        }

        public Task<IEnumerable<Supervisor>> GetAll()
        {
            return _supervisorRepository.GetAll();
        }

        public Task<Supervisor> GetById(int id)
        {
          return  _supervisorRepository.GetById(id);
        }

        public int Update(Supervisor supervisor)
        {
            return _supervisorRepository.Update(supervisor);
        }
    }
}
