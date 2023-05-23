using EmployeeManagement.Model.DBCONTEXT;
using EmployeeManagement.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Repository
{
    public class DepartmentRepository : IDepartmentRepository

    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public Task<Department?> GetDepartmentById(int id)
        {
            var result = _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
            return result;
        }
    }
}
