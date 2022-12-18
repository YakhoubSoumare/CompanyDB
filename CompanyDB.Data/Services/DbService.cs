using AutoMapper;
using CompanyDB.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CompanyDB.Data.Services;

public class DbService : IDbService
{
    private readonly CompanyDBContext _db;
    private readonly IMapper _mapper;

    public DbService(CompanyDBContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity: class, IEntity
        where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }
}
