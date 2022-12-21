namespace CompanyDB.Common.DTO;

public class EmployeePositionDTO
{
    public int EmployeeId { get; set; }
    public int PositionId { get; set; }

    public EmployeePositionDTO (int employeeId, int positionId)
    {
        EmployeeId = employeeId;
        PositionId = positionId;
    }
}
