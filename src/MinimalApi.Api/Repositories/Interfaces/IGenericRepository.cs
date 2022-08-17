using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Repositories.Interfaces;

public interface IGenericRepository<TEntity, TDto> 
    where TEntity : BaseEntity 
    where TDto : BaseDto
{
    Task<IEnumerable<TDto>> GetAsync(Predicate<TEntity>? predicate);
    Task<TDto?> GetByIdAsync(int id);
    Task<int> UpsertAsync(TDto dto);
    Task<int> DeleteAsync(TDto dto);
    Task<int> DeleteAsync(int id);
}