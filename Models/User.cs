﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace kotkangrilli.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public Int64 Snowflake { get; set; }
    [Required]
    public string Username { get; set; }
    public string? Nickname { get; set; }
    public string? Avatar { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? Iban { get; set; }
    [Required]
    [EnumDataType(typeof(UserLevel), ErrorMessage = "Invalid user level.")]

    public UserLevel Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastLogin { get; set; }
}
