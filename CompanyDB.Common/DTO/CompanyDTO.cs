using System.ComponentModel.DataAnnotations;

namespace CompanyDB.Common.DTO;

public class CompanyDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? OrganizationNumber { get; set; }
}
