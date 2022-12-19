using System.Linq.Expressions;
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

    private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
        where TEntity: class, IEntity
    {
        return await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
    }

    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity: class, IEntity
        where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
        where TEntity: class, IEntity
        where TDto: class
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.AddAsync(entity);
        return entity;
    }
}
