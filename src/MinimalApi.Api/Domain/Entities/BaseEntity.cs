using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}