using Microsoft.EntityFrameworkCore;

namespace CompanyDB.Data.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string? FirstName { get; set; }

    [MaxLength(50), Required]
    public string? LastName { get; set; }

    public int DepartmentId { get; set; }
    //Navigation property for Eager-Loading instead of Laser-Loading
    public Department? Department { get; set; }

    [Precision(18,2)]
    public decimal Salary { get; set; }

    public bool TradeUnion { get; set; }

    public virtual ICollection<Position>? Positions { get; set;}
}
