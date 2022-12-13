using CompanyDB.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyDB.Data.Contexts;

public class CompanyDBContext: DbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<EmployeePosition> EmployeePositions => Set<EmployeePosition>();

    public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmployeePosition>().HasKey(ep=> new { ep.EmployeeId, ep.PositionId });

        //SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var companies = new List<Company>
        {
            new Company {
                Id= 1,
                Name= "Fitness Company",
                OrganizationNumber= "5555-4444"
            },
            new Company {
                Id= 2,
                Name= "Test Company",
                OrganizationNumber= "929292Test"
            },
            new Company {
                Id= 3,
                Name= "Third Company",
                OrganizationNumber= "333-333"
            }
        };
        builder.Entity<Company>().HasData(companies);

        var departments = new List<Department>
        {
            new Department
            {
                Id= 1,
                Name= "Economy",
                CompanyId= 1
            },
            new Department
            {
                Id= 2,
                Name= "Market",
                CompanyId= 1
            },
            new Department
            {
                Id= 3,
                Name= "Sales",
                CompanyId= 1
            },
            new Department
            {
                Id= 4,
                Name= "Facility",
                CompanyId= 1
            },
            new Department
            {
                Id= 5,
                Name= "TestDepartment",
                CompanyId= 2
            },
            new Department
            {
                Id= 6,
                Name= "TestDepartment2",
                CompanyId= 3
            }
        };
        builder.Entity<Department>().HasData(departments);

        var employees = new List<Employee>
        {
            new Employee
            {
                Id= 1,
                FirstName= "Yakhoub",
                LastName = "Soumare",
                DepartmentId= 5,
                Salary = 1000.00M,
                TradeUnion = false
            },
            new Employee
            {
                Id= 2,
                FirstName= "Christine",
                LastName = "Svensson",
                DepartmentId= 5,
                Salary = 1500.00M,
                TradeUnion = true
            },
            new Employee
            {
                Id= 3,
                FirstName= "Ismael",
                LastName = "Smith",
                DepartmentId= 5,
                Salary = 800.00M,
                TradeUnion = false
            },
            new Employee
            {
                Id= 4,
                FirstName= "Robban",
                LastName = "Matsson",
                DepartmentId= 2,
                Salary = 2000.00M,
                TradeUnion = true
            },
            new Employee
            {
                Id= 5,
                FirstName= "Eric",
                LastName = "Sarr",
                DepartmentId= 4,
                Salary = 2100.00M,
                TradeUnion = false
            },
            new Employee
            {
                Id= 6,
                FirstName= "Ahmed",
                LastName = "Winclar",
                DepartmentId= 1,
                Salary = 1900.00M,
                TradeUnion = true
            },
            new Employee
            {
                Id= 7,
                FirstName= "Mahe",
                LastName = "Yussuf",
                DepartmentId= 2,
                Salary = 2200.00M,
                TradeUnion = false
            },
            new Employee
            {
                Id= 8,
                FirstName= "Jennifer",
                LastName = "Bavul",
                DepartmentId= 1,
                Salary = 1900.00M,
                TradeUnion = false
            },
            new Employee
            {
                Id= 9,
                FirstName= "Amina",
                LastName = "Nkuku",
                DepartmentId= 4,
                Salary = 2300.00M,
                TradeUnion = true
            },
            new Employee
            {
                Id= 10,
                FirstName= "ttt",
                LastName = "hshs",
                DepartmentId= 6,
                Salary = 200.00M,
                TradeUnion = false
            }
        };
        builder.Entity<Employee>().HasData(employees);

        var positions = new List<Position> 
        { 
            new Position 
            { 
                Id = 1, 
                Title = "Site Responsible"
            },
            new Position
            {
                Id = 2,
                Title = "Site Manager"
            },
            new Position
            {
                Id = 3,
                Title = "Sales Corporate"
            },
            new Position
            {
                Id = 4,
                Title = "Economist"
            },
            new Position
            {
                Id = 5,
                Title = "Financial Manager"
            },
            new Position
            {
                Id = 6,
                Title = "Market Boss"
            },
            new Position
            {
                Id = 7,
                Title = "Marketer"
            },
            new Position
            {
                Id = 8,
                Title = "Area Manager"
            },
            new Position
            {
                Id = 9,
                Title = "TestPosition"
            },
            new Position
            {
                Id = 10,
                Title = "Second TestPosition"
            }
        };
        builder.Entity<Position>().HasData(positions);

        var employeepositions = new List<EmployeePosition>
        {
            new EmployeePosition
            {
                EmployeeId= 1,
                PositionId= 1
            },
            new EmployeePosition
            {
                EmployeeId= 2,
                PositionId= 1
            },
            new EmployeePosition
            {
                EmployeeId= 2,
                PositionId= 2
            },
            new EmployeePosition
            {
                EmployeeId= 3,
                PositionId= 1
            },
            new EmployeePosition
            {
                EmployeeId= 4,
                PositionId= 7
            },
            new EmployeePosition
            {
                EmployeeId= 5,
                PositionId= 3
            },
            new EmployeePosition
            {
                EmployeeId= 6,
                PositionId= 4
            },
            new EmployeePosition
            {
                EmployeeId= 7,
                PositionId= 6
            },
            new EmployeePosition
            {
                EmployeeId= 8,
                PositionId= 5
            },
            new EmployeePosition
            {
                EmployeeId= 9,
                PositionId= 3
            },
            new EmployeePosition
            {
                EmployeeId= 10,
                PositionId= 9
            }
        };
        builder.Entity<EmployeePosition>().HasData(employeepositions);
    }
}
