namespace CompanyDB.Data.Entities;

public class Company : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string? Name { get; set; }

    [MaxLength(20), Required]
    public string? OrganizationNumber { get; set; }
}
