using EmployeeManagement.Model;
using EmployeeManagement.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentManagement.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            var result = await _departmentRepository.GetAllDepartment();
            return Ok(result);
        }
        [HttpGet("departments/{id}")]
        public async Task<ActionResult<Department>> GetDeparment(int id)
        {
            var result = await _departmentRepository.GetDepartmentById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
