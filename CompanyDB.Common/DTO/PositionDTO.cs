using System.ComponentModel.DataAnnotations;

namespace CompanyDB.Common.DTO;

public class PositionDTO
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
