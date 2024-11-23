using System.ComponentModel.DataAnnotations;

namespace kotkangrilli.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Snowflake { get; set; }
    [Required]
    public string Username { get; set; }
    public string? Nickname { get; set; }
    public string? Avatar { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? Bank { get; set; }
    [Required]
    [EnumDataType(typeof(UserLevel), ErrorMessage = "Invalid user level.")]

    public UserLevel Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastLogin { get; set; }
}
