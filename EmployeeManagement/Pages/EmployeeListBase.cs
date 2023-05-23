using EmployeeManagement.Model;
using EmploymentManagement.API.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections;

namespace EmployeeManagement.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeServiceHttp _EmployeeServiceHttp { get; set; }
        public bool showFooter { get; set; } = true;
       protected IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
       

        protected  override async Task OnInitializedAsync()
        {
            Employees = (await _EmployeeServiceHttp.GetEmployeesAsync()).ToList();
           
            
        }
        protected int selectedEmployeeCount { get; set; }
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                selectedEmployeeCount++;
            }else { selectedEmployeeCount--; }
        }
        protected async Task EmployeeDelete()
        {
            Employees = (await _EmployeeServiceHttp.GetEmployeesAsync()).ToList();
        }

        //public void LoadEmployee()
        //{
        //    System.Threading.Thread.Sleep(10000);
        //    var emp1 = new Employee()
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Saheed",
        //        LastName = "Olawale",
        //        Email = "bsaheed79@gmail.com",
        //        DateOfBirth = new DateTime(1998, 4, 29),
        //        Gender = Gender.Male,
        //        DepartmentId =1,

        //        PhotoPath = "sh.jpg"
        //    };
        //    var emp2 = new Employee()
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Test",
        //        LastName = "Testing",
        //        Email = "test79@gmail.com",
        //        DateOfBirth = new DateTime(1998, 4, 29),
        //        Gender = Gender.Male,
        //        DepartmentId = 2,

        //        PhotoPath = "mn1.jpg"
        //    };
        //    var emp3 = new Employee()
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Test2",
        //        LastName = "Testing2",
        //        Email = "test7@gmail.com",
        //        DateOfBirth = new DateTime(1998, 4, 29),
        //        Gender = Gender.Female,
        //        DepartmentId = 3,
        //        //Department = new Department()
        //        //{
        //        //    DepartmentId = 2,
        //        //    DepartmentName = "Main Worker"
        //        //},
        //        PhotoPath = "wn1.jpg"
        //    };
        //    Employees = new List<Employee>() { emp1, emp2, emp3 };
        //}
    }
}
