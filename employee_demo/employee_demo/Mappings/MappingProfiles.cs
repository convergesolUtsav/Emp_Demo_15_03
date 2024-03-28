using AutoMapper;
using Emp_Core;
using employee_demo.DTOs;

namespace employee_demo.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {

            CreateMap<Department, DepartmentRequestDTO>()
              .ReverseMap();

            CreateMap<Department, DepartmentResponseDTO>()
              .ReverseMap();


            CreateMap<Supervisor, SupervisorRequestDTO>()
              .ReverseMap();


            CreateMap<Supervisor, SupervisorResponseDTO>()
              .ReverseMap();


            CreateMap<Employee, EmployeeRequestDTO>()
              .ReverseMap();

            CreateMap<Employee, EmployeeResponseDTO>()
              .ReverseMap();


            CreateMap<Address, AddressDTO>()
              .ReverseMap();

            CreateMap<EmergencyContact, EmergencyContactDTO>()
              .ReverseMap();
        
        }
    }
}
