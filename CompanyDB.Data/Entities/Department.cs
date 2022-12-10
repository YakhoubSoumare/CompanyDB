namespace CompanyDB.Data.Entities;

public class Department : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string? Name { get; set; }

    public int CompanyId { get; set; }
    //Navigation property for Eager-Loading instead of Laser-Loading
    public Company? Company { get; set; }

    public virtual ICollection<Employee>? Employees { get;}
}
