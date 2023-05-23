using EmployeeManagement.Model;

namespace EmploymentManagement.API.Service
{
    public interface IEmployeeServiceHttp
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<Employee> UpdateEmployeeAsync(Employee updateEmployee);
        Task<Employee> CreateEmployeeAsync(Employee newEmployee);
        Task DeleteEmployeeAsync(int id);
    }
}
