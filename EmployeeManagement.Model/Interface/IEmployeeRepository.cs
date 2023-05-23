using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeAsync(int employeeId);
        Task<Employee?> GetEmployeeByEmailAsync(Employee employee);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(int employeeId);
    }
}
