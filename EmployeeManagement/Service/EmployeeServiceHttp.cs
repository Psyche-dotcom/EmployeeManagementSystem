using EmployeeManagement.Model;

namespace EmploymentManagement.API.Service
{
    public class EmployeeServiceHttp : IEmployeeServiceHttp
    {
        private readonly HttpClient _httpClient;

        public EmployeeServiceHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            var rest = await _httpClient.PostAsJsonAsync("api/employees/addemployee", newEmployee);
            var result = await rest.Content.ReadFromJsonAsync<Employee>();
            return result;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/employees/delete/{id}");
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<Employee[]>("api/employees");
            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee updateEmployee)
        {
            var rest = await _httpClient.PutAsJsonAsync("api/employees/update", updateEmployee);
            var result = await rest.Content.ReadFromJsonAsync<Employee>();
            return result;
        }

    }
}
