using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model.DBCONTEXT
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding of Department Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "Marketing" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Finance" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Saheed",
                LastName = "Babatunde",
                Email = "bsaheed79@gmail.com",
                DateOfBirth = new DateTime(1998, 4, 29),
                Gender = Gender.Male,
                DepartmentId = 1,

                PhotoPath = "sh.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Ola",
                LastName = "Sola",
                Email = "test79@gmail.com",
                DateOfBirth = new DateTime(1998, 4, 29),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "mn1.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Test2",
                LastName = "Testing2",
                Email = "test7@gmail.com",
                DateOfBirth = new DateTime(1998, 4, 29),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "wn1.jpg"
            });
        }
    }
}
