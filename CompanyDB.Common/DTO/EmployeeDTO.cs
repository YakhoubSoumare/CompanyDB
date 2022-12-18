using System.ComponentModel.DataAnnotations;

namespace CompanyDB.Common.DTO;

public class EmployeeDTO
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public bool TradeUnion { get; set; }
}
