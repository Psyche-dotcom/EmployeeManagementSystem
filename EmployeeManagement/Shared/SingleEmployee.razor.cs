using EmployeeManagement.Model;
using EmploymentManagement.API.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Shared
{
    public partial class SingleEmployee
    {
        [Parameter]
        public Employee employee { get; set; }
        [Parameter] 
        public bool showFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        [Inject]
        IEmployeeServiceHttp employeeServiceHttp { get; set; }
        protected Psyche.Component.ConfirmDelete DeleteConfirmation { get; set; }
        public  void DeleteEmployee()
        {
            DeleteConfirmation.Show();
        }
        public async Task ConfirmDelete_CLick(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await employeeServiceHttp.DeleteEmployeeAsync(employee.EmployeeId);
               await OnEmployeeDeleted.InvokeAsync(employee.EmployeeId);
            }
        }
        //public async Task DeleteEmployee()
        //{
        //    await employeeServiceHttp.DeleteEmployeeAsync(employee.EmployeeId);
        //    await OnEmployeeDeleted.InvokeAsync(employee.EmployeeId);
        //}
        protected async Task CheckBoxChanged(ChangeEventArgs args)
        {
            await OnEmployeeSelection.InvokeAsync((bool)args.Value);
        }
    }
}
