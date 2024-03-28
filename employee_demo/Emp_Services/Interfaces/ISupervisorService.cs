using Emp_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_Services.Interfaces
{
    public interface ISupervisorService
    {
        Task<Supervisor> GetById(int id);
        Task<IEnumerable<Supervisor>> GetAll();
        Task<int> Add(Supervisor supervisor);
        int Update(Supervisor supervisor);
        Task<bool> Delete(int id);
    }
}
