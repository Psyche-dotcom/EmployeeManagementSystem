using EmployeeManagement.Model.DBCONTEXT;
using EmployeeManagement.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            var getEmployeeToDelete = await GetEmployeeAsync(employeeId);
            if (getEmployeeToDelete != null)
            {
                _dbContext.Employees.Remove(getEmployeeToDelete);
                var affected = await _dbContext.SaveChangesAsync();
                if (affected < 0)
                {
                    throw new Exception("Deletion not Successfuly");
                }
                return affected;
            }
            else
            {
                return 0;
            };

        }

        public async Task<Employee?> GetEmployeeAsync(int employeeId)
        {
            var result = await _dbContext.Employees.Include(e=> e.Department).
                FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            return result;
        }

        public async Task<Employee?> GetEmployeeByEmailAsync(Employee employee)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Email == employee.Email);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();

        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _dbContext.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var updateContact = _dbContext.Employees.Update(employee);
            var affectedResult = await _dbContext.SaveChangesAsync();
            if (affectedResult > 0)
            {
                return updateContact.Entity;
            }
            throw new Exception("Contact not updated successfully");

        }
    }
}
