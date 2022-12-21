using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanyDBContext>(
options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("CompanyDBConnection")));

ConfigureAutomapper(builder.Services);
RegisterService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAutomapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
        cfg.CreateMap<Company, CompanyDTO>().ReverseMap();
        cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
        cfg.CreateMap<Position, PositionDTO>().ReverseMap();
        cfg.CreateMap<EmployeePosition, EmployeePositionDTO>().ReverseMap();
    });

    var mapper = config.CreateMapper();

    services.AddSingleton(mapper);
}

void RegisterService(IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
}