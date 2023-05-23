using EmployeeManagement.Model;
using EmployeeManagement.Service;
using EmploymentManagement.API.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Pages
{
    public partial class EditEmployee
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IEmployeeServiceHttp _EmployeeServiceHttp { get; set; }
        [Inject]
        public IDepartmentServiceHttp _DepartmentServiceHttp { get; set; }
        [Inject]
        public NavigationManager _NavigationManager { get; set; }
        public string HeaderText { get; set; }
        public Employee _Employee { get; set; } = new Employee();
        public IEnumerable<Department> _Departments { get; set; } = new List<Department>();
        public string DepartmentId { get; set; }
        protected Psyche.Component.ConfirmDelete DeleteConfirmation { get; set; }
        public async Task Delete_Click()
        {

            DeleteConfirmation.Show();
        }
        public async Task ConfirmDelete_CLick(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await _EmployeeServiceHttp.DeleteEmployeeAsync(_Employee.EmployeeId);
                _NavigationManager.NavigateTo("/");
            }
        }
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if (employeeId != 0)
            {
                _Employee = await _EmployeeServiceHttp.GetEmployeeAsync(int.Parse(Id));
                HeaderText = "Edit Employee";
            }
            else
            {
                HeaderText = "Create Employee";
                _Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "sh.jpg"
                };
            }
            
            _Departments = (await _DepartmentServiceHttp.GetDepartmentAsync()).ToList();
            DepartmentId = _Employee.DepartmentId.ToString();
        }
       
        public async Task HandleSubmited() {
            Employee result = null;
            if(_Employee.EmployeeId != 0)
            {
                 result = await _EmployeeServiceHttp.UpdateEmployeeAsync(_Employee);

            }
            else
            {
               result = await _EmployeeServiceHttp.CreateEmployeeAsync(_Employee);
            }
           
           
            if (result != null)
            {
                _NavigationManager.NavigateTo("/");
            }
        
        }
        


    }
}
