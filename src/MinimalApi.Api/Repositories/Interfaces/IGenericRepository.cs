using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Repositories.Interfaces;

public interface IGenericRepository<TEntity, TDto> 
    where TEntity : BaseEntity 
    where TDto : BaseDto
{
    Task<IEnumerable<TDto>> GetAsync(Predicate<TEntity>? predicate = null);
    Task<TDto?> GetByIdAsync(string id);
    Task<string> UpsertAsync(TDto dto);
    Task<string> DeleteAsync(TDto dto);
    Task<string> DeleteAsync(string id);
}