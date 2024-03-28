using AutoMapper;
using Emp_Core;
using Emp_Infrastructure.context;
using Emp_Services.Interfaces;
using Emp_Services.Services;
using employee_demo.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IEmployeeService _employeeService; 
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeDbContext employeeDbContext, IEmployeeService employeeService, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        #region GetById
        [HttpGet("GetByIdEmployee")]
        public async Task<ResponseDTO<EmployeeResponseDTO>> GetEmployee(int id)
        {
            ResponseDTO<EmployeeResponseDTO> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            EmployeeResponseDTO Response = null;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var employee = await _employeeService.GetById(id);
                if (employee == null)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "employee not found";
                }
                else
                {
                    var data = _mapper.Map<EmployeeResponseDTO>(employee);
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "employee fetched successfully";
                    Response = data;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                StatusCode = 500;
                Message = "Failed while fetching data.";
                ExceptionMessage = ex.Message.ToString();
            }
            response.StatusCode = StatusCode;
            response.IsSuccess = isSuccess;
            response.Response = Response;
            response.Message = Message;
            response.ExceptionMessage = ExceptionMessage;
            return response;
        }
        #endregion

        #region GetAll
        [HttpGet("GetAllEmployee")]
        public async Task<ResponseDTO<IEnumerable<EmployeeResponseDTO>>> GetAllEmployee()
        {
            ResponseDTO<IEnumerable<EmployeeResponseDTO>> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            IEnumerable<EmployeeResponseDTO> Response = null;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var result = await _employeeService.GetAll();
                if (result == null)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "No employees found";
                }
                else
                {
                    var employee = _mapper.Map<List<EmployeeResponseDTO>>(result);
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Employees fetched successfully";
                    Response = employee;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                StatusCode = 500;
                Message = "Failed while fetching data.";
                ExceptionMessage = ex.Message.ToString();
            }
            response.StatusCode = StatusCode;
            response.IsSuccess = isSuccess;
            response.Response = Response;
            response.Message = Message;
            response.ExceptionMessage = ExceptionMessage;
            return response;
        }
        #endregion

        #region AddEmployee
        [HttpPost("createEmployee")]

        public async Task<ResponseDTO<int>> CreateEmployee(EmployeeRequestDTO employeeRequest)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            int StatusCode = 0;
            bool isSuccess = false;
            int Response = 0;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var employee = _mapper.Map<Employee>(employeeRequest);
                var employeeId = await _employeeService.Add(employee);
                if (employeeId == 0)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while employee add";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Employee added successfully";
                    Response = employeeId;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                StatusCode = 500;
                Message = "Failed while fetching data.";
                ExceptionMessage = ex.Message.ToString();
            }
            response.StatusCode = StatusCode;
            response.IsSuccess = isSuccess;
            response.Response = Response;
            response.Message = Message;
            response.ExceptionMessage = ExceptionMessage;
            return response;
        }
        #endregion


        #region DeleteEmployee
        [HttpDelete("DeleteEmployee")]
        public async Task<ResponseDTO<bool>> DeleteEmployee(int id)
        {
            ResponseDTO<bool> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            bool Response = false;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var isDeleted = await _employeeService.Delete(id);
                Response = isDeleted;
                if (!isDeleted)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while employee remove";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "employee removed successfully";
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                StatusCode = 500;
                Message = "Failed while fetching data.";
                ExceptionMessage = ex.Message.ToString();
            }
            response.StatusCode = StatusCode;
            response.IsSuccess = isSuccess;
            response.Response = Response;
            response.Message = Message;
            response.ExceptionMessage = ExceptionMessage;
            return response;
        }
        #endregion


        #region UpdateEmployee
        [HttpPut("UpdateEmployee")]
        public async Task<ResponseDTO<int>> UpdateEmployee(EmployeeRequestDTO employeeRequest)
        {
            ResponseDTO<int> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            int Response = 0;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var employee = _mapper.Map<Employee>(employeeRequest);
                int employeeId = await _employeeService.Update(employee);
                if (employeeId == 0)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while Employee update";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Employee updated successfully";
                    Response = employeeId;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                StatusCode = 500;
                Message = "Failed while fetching data";
            }
            response.StatusCode = StatusCode;
            response.IsSuccess = isSuccess;
            response.Response = Response;
            response.Message = Message;
            response.ExceptionMessage = ExceptionMessage;
            return response;
        }
        #endregion


    }
}
