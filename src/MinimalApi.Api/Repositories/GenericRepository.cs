using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;
using MinimalApi.Api.Persistence;
using MinimalApi.Api.Repositories.Interfaces;

namespace MinimalApi.Api.Repositories;

public abstract class GenericRepository<TEntity, TDto> : IGenericRepository<TEntity, TDto> 
    where TEntity: BaseEntity 
    where TDto : BaseDto 
{
    private readonly DbSet<TEntity> _table;
    protected readonly IAppDbContext Context;
    protected readonly IMapper Mapper;

    protected GenericRepository(DbSet<TEntity> table, IAppDbContext context, IMapper mapper)
    {
        _table = table;
        Context = context;
        Mapper = mapper;
    }

    public virtual async Task<IEnumerable<TDto>> GetAsync(Predicate<TEntity>? predicate = null)
    {
        IQueryable<TEntity> queryable = _table.AsNoTracking();
        if (predicate != null)
            queryable = queryable.Where(e => predicate(e));
        IEnumerable<TDto> result = Mapper.Map<IEnumerable<TDto>>(await queryable.ToListAsync());
        return result;
    }

    public virtual async Task<TDto?> GetByIdAsync(string id)
    {
        TEntity? drink = await _table.AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == id);
        if (drink == null) return default;
        return Mapper.Map<TDto>(drink);
    }

    public virtual async Task<string> UpsertAsync(TDto dto)
    {
        TEntity? entity;
        if (dto.Id == null)
        {
            entity = Mapper.Map<TEntity>(dto);
            entity.Id = Guid.NewGuid().ToString(); 
            _table.Add(entity);
        }
        else
        {
            entity = await _table.FindAsync(dto.Id);
            Mapper.Map(dto, entity);
        }
        
        await Context.SaveChangesAsync();
        return entity!.Id;
    }

    public virtual Task<string> DeleteAsync(TDto dto)
    {
        if (dto.Id == null)
            throw new ArgumentNullException();
        return DeleteAsync(dto.Id);
    }

    public virtual async Task<string> DeleteAsync(string id)
    {
        TEntity? entity = await _table.SingleOrDefaultAsync(e => e.Id == id);
        if (entity == null)
            throw new KeyNotFoundException();
        _table.Remove(entity);
        await Context.SaveChangesAsync();
        return id;
    }
}