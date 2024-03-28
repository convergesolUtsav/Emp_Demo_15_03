using Emp_Core;

namespace employee_demo.DTOs
{
    public class EmployeeRequestDTO
    {
        public int Id { get; set; }
       public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentID { get; set; }
       // public Department Department { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public DateTime? DateHired { get; set; }
        public int SupervisorId { get; set; }
        //public Supervisor Supervisor { get; set; }
        public int EmploymentStatus { get; set; }

        public List<AddressDTO>? Addresses { get; set; }
       public List<EmergencyContactDTO> EmergencyContacts { get; set; }


    }
}
