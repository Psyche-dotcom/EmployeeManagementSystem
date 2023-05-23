using EmployeeManagement.Model;

namespace EmployeeManagement.Service
{
    public class DepartmentServiceHttp : IDepartmentServiceHttp
    {
        private readonly HttpClient _httpClient;

        public DepartmentServiceHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Department>> GetDepartmentAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<Department[]>("api/departments");
            return result;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Department>($"api/departments/{id}");
            return result;
        }
    }
}
