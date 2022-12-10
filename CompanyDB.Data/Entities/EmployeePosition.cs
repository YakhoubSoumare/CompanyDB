namespace CompanyDB.Data.Entities;

public class EmployeePosition: IReferenceEntity
{
    public int EmployeeId { get; set; }
    public int PositionId { get; set; }

    //Creation of objects to enable Eager-Loading
    public Employee? Employee { get; set; }
    public Position? Position { get; set; }
}
