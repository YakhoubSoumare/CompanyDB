using CompanyDB.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDB.API.Extensions;

public static class HttpExtensions
{
    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService _db)
     where TEntity : class, IEntity
     where TDto : class
    {
        return Results.Ok(await _db.GetAsync<TEntity, TDto>());
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService _db, int id)
     where TEntity : class, IEntity
     where TDto : class
    {
        var result = await _db.SingleAsync<TEntity, TDto>(e => e.Id.Equals(id));
        if (result == null) { return Results.NotFound(); }
        return Results.Ok(result);
    }

    public static async Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService _db, TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        if (dto == null) return Results.BadRequest();

        try
        {
            var entity = await _db.AddAsync<TEntity, TDto>(dto);
            if (await _db.SaveChangesAsync())
            {
                string URI = string.Empty;
                var node = typeof(TEntity).Name.ToLower();
                if (node.EndsWith("y"))
                {
                    URI = $"{node.Remove(node.Length - 1, 1) + "ie"}s/{entity.Id}";
                }
                else
                {
                    URI = $"{node}s/{entity.Id}";
                }
                
                return Results.Created(URI, entity);
            }
        }
        catch { }

        return Results.BadRequest();
    }

    public static async Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService _db, int id, TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        if (dto == null) return Results.BadRequest();

        if (!await _db.AnyAsync<TEntity>(i => i.Id.Equals(id))) return Results.NotFound();

        try
        {
            _db.Update<TEntity, TDto>(id, dto);
            if (await _db.SaveChangesAsync())
            {
                return Results.NoContent();
            }

        }
        catch
        { }
        return Results.NotFound("Could not update entity!");
    }

    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService _db, int id)
    where TEntity : class, IEntity
    {
        try
        {
            if (!await _db.DeleteAsync<TEntity>(id)) return Results.NotFound();
            if (await _db.SaveChangesAsync()) return Results.NoContent();
        }
        catch { throw; }
        return Results.BadRequest("Not Possible!");
    }

    public static async Task<IResult> HttpDeleteAsync<TRefereceEntity, TDto>(this IDbService _db, TDto dto)
    where TRefereceEntity : class, IReferenceEntity
    where TDto : class
    {
        try
        {
            if (!_db.Delete<TRefereceEntity, TDto>(dto)) return Results.NotFound();
            if (await _db.SaveChangesAsync()) return Results.NoContent();
        }
        catch { throw; }
        return Results.BadRequest("Not Possible!");
    }

    public static async Task<IResult> HttpPost<TRefereceEntity, TDto>(this IDbService _db,  TDto dto)
    where TRefereceEntity : class, IReferenceEntity
    where TDto : class
    {
        if (dto == null) return Results.BadRequest();
        try
        {
            var entity = await _db.PostAsync<TRefereceEntity, TDto>(dto);
            if (await _db.SaveChangesAsync())
            {
                string URI = string.Empty;
                var node = typeof(TRefereceEntity).Name.ToLower();
                if (node.EndsWith("y"))
                {
                    URI = $"{node.Remove(node.Length - 1, 1) + "ie"}s";
                }
                else
                {
                    URI = $"{node}s";
                }

                return Results.Created(URI, entity);
            }
        }
        catch { }
        return Results.BadRequest();
    }


}
