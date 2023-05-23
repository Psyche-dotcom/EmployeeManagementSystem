using AutoMapper;
using EmployeeManagement.Model;
using EmployeeManagement.Model.Interface;
using EmployeeManagement.Model.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentManagement.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var result = await _employeeRepository.GetEmployeesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("employees/{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            try
            {
                var retriveEmployee = await _employeeRepository.GetEmployeeAsync(id);
                if (retriveEmployee == null)
                {
                    return NotFound(new
                    {
                        Id = id,
                        Message = "Employee with the id not found"
                    });
                }
                return Ok(retriveEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("employees/search")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string? name, Gender? gender)
        {
            try
            {
                var result = await _employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("employees/addemployee")]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {
                var mappedEmployee = _mapper.Map<Employee>(employeeDto);
                var checkEmployeeWithEmail = await _employeeRepository.GetEmployeeByEmailAsync(mappedEmployee);
                if (checkEmployeeWithEmail != null)
                {
                    ModelState.AddModelError("Email", "This email is used by another employee");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var addEmployee = await _employeeRepository.AddEmployeeAsync(mappedEmployee);
                if (addEmployee == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to the database");
                }
                return Ok(addEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to the database");
            }

        }
        [HttpPut("employees/update")]
        public async Task<IActionResult> UpdateEmployeeDetails(Employee employee)
        {
            try
            {

                //var mapUpdateItem = new Employee()
                //{
                //    EmployeeId = id,
                //    FirstName = employee.FirstName,
                //    LastName = employee.LastName,
                //    Email = employee.Email,
                //    DateOfBirth = employee.DateOfBirth,
                //    Gender = employee.Gender,
                //    DepartmentId = employee.DepartmentId,
                //    PhotoPath = employee.PhotoPath
                //};
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updateItem = await _employeeRepository.UpdateEmployeeAsync(employee);
                if (updateItem == null)
                {
                    return NotFound(new
                    {
                        EmployeeId = employee.EmployeeId,
                        Message = $"The employee with the id not found",
                        StatusCode = StatusCodes.Status404NotFound,
                    });
                }
                else
                {
                    return Ok(updateItem);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data to the database");
            }
        }
        [HttpDelete("employees/delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.DeleteEmployeeAsync(id);
                if (result < 0)
                {
                    return NotFound(new
                    {
                        EmployeeId = id,
                        Message = "Employee with the id for deletion not found",
                        StatusCode = StatusCodes.Status406NotAcceptable,

                    });
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
