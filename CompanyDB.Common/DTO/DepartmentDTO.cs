using System.ComponentModel.DataAnnotations;

namespace CompanyDB.Common.DTO;

public class DepartmentDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int CompanyId { get; set; }
}
