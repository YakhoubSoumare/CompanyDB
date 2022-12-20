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

    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.AddAsync(entity);
        return entity;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
    where TEntity : class, IEntity
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }

    public void Update<TEntity, TDto>(int id, TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }

    public async Task<bool> DeleteAsync<TEntity>(int id)
    where TEntity : class, IEntity
    {
        try
        {
            var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch { throw; }
        return true;
    }
}