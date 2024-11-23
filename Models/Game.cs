using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kotkangrilli.Models;

public class Game
{
    public int Id { get; set; }
    [Required]
    public int ExternalId { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Image { get; set; }
    public int? Price { get; set; }
    public string? Link { get; set; }
    public GameStore Store { get; set; }
    public int? Players { get; set; }
    [Required]
    public int IsLan { get; set; }
    
    // Foreign Key property
    [Required]
    public User SubmittedById { get; set; }
    
    // Navigation property
    [ForeignKey("SubmittedById")]
    public User SubmittedBy { get; set; }
    
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}