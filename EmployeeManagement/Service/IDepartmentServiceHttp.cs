using EmployeeManagement.Model;

namespace EmployeeManagement.Service
{
    public interface IDepartmentServiceHttp
    {
        Task<IEnumerable<Department>> GetDepartmentAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
    }
}
