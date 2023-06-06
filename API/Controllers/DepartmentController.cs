using Business.Services.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] DepartmentDto departmentDto)
        {
            var department = _departmentService.AddDepartment(departmentDto);
            if (department == null)
            {
                _logger.LogWarning("Failed to add department");
                return BadRequest();
            }
            _logger.LogInformation("Department added successfully: {@Department}", department);
            return Ok(department);
        }

        [HttpPut]
        public IActionResult EditDepartment([FromBody] DepartmentDto departmentDto)
        {
            var department = _departmentService.EditDepartment(departmentDto);
            if (department == null)
            {
                _logger.LogWarning("Failed to edit department with ID {Id}", departmentDto.DepartmentId);
                return NotFound();
            }
            _logger.LogInformation("Department with ID {Id} edited successfully: {@Department}", departmentDto.DepartmentId, department);
            return Ok(department);
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _departmentService.GetAllDepartment();
            _logger.LogInformation("Retrieved all departments: {@Departments}", departments);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(Guid id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                _logger.LogWarning("Failed to get department with ID {Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Retrieved department with ID {Id}: {@Department}", id, department);
            return Ok(department);
        }

        [HttpGet("count")]
        public IActionResult GetTotalNumberOfDepartments()
        {
            var count = _departmentService.GetTotalNumberOfDepartments();
            _logger.LogInformation("Retrieved total number of departments: {Count}", count);
            return Ok(count);
        }

        [HttpGet("{id}/email")]
        public IActionResult GetDepartmentMailById(Guid id)
        {
            var email = _departmentService.GetDepartmentMailById(id);
            if (email == null)
            {
                _logger.LogWarning("Failed to get email for department with ID {Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Retrieved email for department with ID {Id}: {Email}", id, email);
            return Ok(email);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(Guid id)
        {
            var result = _departmentService.DeleteDepartment(id);
            if (result == null)
            {
                _logger.LogWarning("Failed to delete department with ID {Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Department with ID {Id} deleted successfully", id);
            return Ok(result);
        }

        [HttpGet("{id}/status")]
        public IActionResult GetStatusById(Guid id)
        {
            var status = _departmentService.GetStatusById(id);
            if (status == null)
            {
                _logger.LogWarning("Failed to get status for department with ID {Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Retrieved status for department with ID {Id}: {Status}", id, status);
            return Ok(status);
        }
    }
}

