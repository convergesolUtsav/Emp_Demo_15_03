using AutoMapper;
using Emp_Core;
using Emp_Infrastructure.context;
using Emp_Services.Interfaces;
using employee_demo.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employee_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;


        public DepartmentController(EmployeeDbContext employeeDbContext,IDepartmentService departmentService, IMapper mapper)

        {

            _employeeDbContext = employeeDbContext;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        #region GetById
        [HttpGet("GetByIdDepartment")]
        public async Task<ResponseDTO<DepartmentResponseDTO>> GetDepartment(int id)
        {
            ResponseDTO<DepartmentResponseDTO> response = new ResponseDTO<DepartmentResponseDTO>();
            int StatusCode = 0;
            bool isSuccess = false;
            DepartmentResponseDTO Response = null;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var department = await _departmentService.GetById(id);
                if (department == null)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Department not found";
                }
                else
                {
                    var data = _mapper.Map<DepartmentResponseDTO>(department);
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Department fetched successfully";
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
        [HttpGet("GetAllDepartments")]
        public async Task<ResponseDTO<IEnumerable<DepartmentResponseDTO>>> GetAllDepartment()
            {
            ResponseDTO<IEnumerable<DepartmentResponseDTO>> response = new ResponseDTO<IEnumerable<DepartmentResponseDTO>>();
            int StatusCode = 0;
            bool isSuccess = false;
            IEnumerable<DepartmentResponseDTO> Response = null;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var result = await _departmentService.GetAll();
                if(result == null)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = " Departments not  found";
                }
                else
                {
                    var department = _mapper.Map<List<DepartmentResponseDTO>>(result);
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Departments  fetched successfully";
                    Response = department;
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

        #region AddDepartment
        [HttpPost("createDepartment")]

        public async Task<ResponseDTO<int>> CreateDepartment(DepartmentRequestDTO departmentRequest)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            int StatusCode = 0;
            bool isSuccess = false;
            int Response = 0;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var department = _mapper.Map<Department>(departmentRequest);
                var departmentId = await _departmentService.Add(department);
                if (departmentId == 0)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while department add";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Department added successfully";
                    Response = departmentId;
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

        #region DeleteDepartment
        [HttpDelete("DeleteDepartment")]
        public async Task<ResponseDTO<bool>> DeleteDepartment(int id)
        {
            ResponseDTO<bool> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            bool Response = false;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var isDeleted = await _departmentService.Delete(id);
                Response = isDeleted;
                if (!isDeleted)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while Department remove";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Department removed successfully";
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

        #region UpdateDepartment
        [HttpPut("UpdateDepartment")]

        public async Task<ResponseDTO<int>> UpdateDepartment(DepartmentRequestDTO departmentRequest)
        {
            ResponseDTO<int> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            int Response = 0;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var department = _mapper.Map<Department>(departmentRequest);
                department.Id = departmentRequest.Id;
                int departmentId = await _departmentService.Update(department);
                if( departmentId == 0 )
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while Department update";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Department updated successfully";
                    Response = departmentId;
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
