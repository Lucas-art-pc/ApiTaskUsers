using System.ComponentModel.DataAnnotations;

namespace ApiTaskUsers.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Name must be at most 100 characters long.")]
    public string Name { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Email must be at most 100 characters long.")]
    public string Email { get; set; }

    public IEnumerable<Question> Questions { get; set; }
}
