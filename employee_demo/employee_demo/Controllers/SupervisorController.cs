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
    public class SupervisorController : ControllerBase
    {

        private readonly EmployeeDbContext _employeeDbContext;
        private readonly ISupervisorService _supervisorService;
        private readonly IMapper _mapper;

        public SupervisorController(EmployeeDbContext employeeDbContext, ISupervisorService supervisorService, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _supervisorService = supervisorService;
            _mapper = mapper;
        }


        #region GetById
        [HttpGet("GetByIdSupervisor")]
        public async Task<ResponseDTO<SupervisorResponseDTO>> GetSupervisorById(int id)
        {
            ResponseDTO<SupervisorResponseDTO> response = new ResponseDTO<SupervisorResponseDTO>();
            int StatusCode = 0;
            bool isSuccess = false;
            SupervisorResponseDTO Response = null;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var supervisor = await _supervisorService.GetById(id);
                if (supervisor == null)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "supervisor not found";
                }
                else
                {
                    var data = _mapper.Map<SupervisorResponseDTO>(supervisor);
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "supervisor fetched successfully";
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
        [HttpGet("GetAllSuperviser")]
        public async Task<ResponseDTO<IEnumerable<SupervisorResponseDTO>>> GetAllSuperviser()
        {
            ResponseDTO<IEnumerable<SupervisorResponseDTO>> response = new ResponseDTO<IEnumerable<SupervisorResponseDTO>>();
            int StatusCode = 0;
            bool isSuccess = false;
            IEnumerable<SupervisorResponseDTO> Response = null;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                
                var result = await _supervisorService.GetAll();
                if (result == null)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "No supervisor found";
                }
                else
                {
                    var supervisor = _mapper.Map<List<SupervisorResponseDTO>>(result);
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "supervisor fetched successfully";
                    Response = supervisor;
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

        #region AddSupervisor
        [HttpPost("createSupervisor")]

        public async Task<ResponseDTO<int>> CreateSupervisor(SupervisorRequestDTO supervisorRequest)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            int StatusCode = 0;
            bool isSuccess = false;
            int Response = 0;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var supervisor = _mapper.Map<Supervisor>(supervisorRequest);
                var supervisorId = await _supervisorService.Add(supervisor);
                if (supervisorId == 0)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while supervisor add";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Supervisor added successfully";
                    Response = supervisorId;
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

        #region DeleteSupervisor
        [HttpDelete("DeleteSupervisor")]
        public async Task<ResponseDTO<bool>> DeleteSupervisor(int id)
        {
            ResponseDTO<bool> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            bool Response = false;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var isDeleted = await _supervisorService.Delete(id);
                Response = isDeleted;
                if (!isDeleted)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while Supervisor remove";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Supervisor removed successfully";
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

        #region UpdateSupervisor
        [HttpPut("UpdateSupervisor")]

        public ResponseDTO<int> UpdateSupervisor(SupervisorRequestDTO supervisorRequest)
        {
            ResponseDTO<int> response = new();
            int StatusCode = 0;
            bool isSuccess = false;
            int Response = 0;
            string Message = "";
            string ExceptionMessage = "";
            try
            {
                var supervisor = _mapper.Map<Supervisor>(supervisorRequest);

                int supervisorId = _supervisorService.Update(supervisor);
                if (supervisorId == 0)
                {
                    isSuccess = false;
                    StatusCode = 400;
                    Message = "Error occurred while Supervisor update";
                }
                else
                {
                    StatusCode = 200;
                    isSuccess = true;
                    Message = "Supervisor updated successfully";
                    Response = supervisorId;
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
