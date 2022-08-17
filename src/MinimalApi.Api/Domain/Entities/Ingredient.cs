﻿using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Ingredient : BaseEntity
{
    [Required]
    public string Name { get; set; }
}