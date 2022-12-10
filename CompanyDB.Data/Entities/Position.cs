namespace CompanyDB.Data.Entities;

public class Position : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string? Title { get; set; }

    public virtual ICollection<Employee>? Employees { get; set;}
}
