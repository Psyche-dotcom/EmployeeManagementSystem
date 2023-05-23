using EmployeeManagement.Model;
using EmploymentManagement.API.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        IEmployeeServiceHttp _employeeServiceHttp { get; set; }
        public Employee _Employee { get; set; }
        protected string _cordinate { get; set; }
        public string btn_text { get; set; } = "Hide Footer";
        public string cssstyle { get; set; } = null;
        public void mouse_move(MouseEventArgs e)
        {
            _cordinate = $"MouseX: {e.ClientX} MouseY: {e.ClientY}";
        }

        protected override async Task OnInitializedAsync()
        {
            _Employee = await _employeeServiceHttp.GetEmployeeAsync(int.Parse(Id));
        }
        public void OnclickBtn()
        {
            if(btn_text =="Hide Footer")
            {
                btn_text = "Show Footer";
                cssstyle = "HideFooter";
            }
            else
            {
                btn_text = "Hide Footer";
                cssstyle = null;
            }
        }
    }
}
