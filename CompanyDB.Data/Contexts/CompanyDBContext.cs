using CompanyDB.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyDB.Data.Contexts;

public class CompanyDBContext: DbContext
{
    public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmployeePosition>().HasKey(ep=> new { ep.EmployeeId, ep.PositionId });
    }
}
