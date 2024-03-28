using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_Core
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public int DepartmentID { get; set; }
      public  Department Department { get; set; }
        public string Position { get; set; }
        public int  Salary { get; set; }
        public DateTime? DateHired { get; set; }
        public int SupervisorId { get; set; }
     public  Supervisor Supervisor { get; set; }
        public int EmploymentStatus { get; set; }

        public List<Address>? Addresses { get; set; }
        public List<EmergencyContact>? EmergencyContacts { get; set; }


    }
}
