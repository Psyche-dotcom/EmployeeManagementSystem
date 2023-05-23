using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Interface
{
    public interface IDepartmentRepository
    {
      Task <Department?> GetDepartmentById(int id);
      Task<IEnumerable<Department>> GetAllDepartment();
    }
}
