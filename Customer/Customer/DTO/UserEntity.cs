using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Customer.DTO;

[Index(nameof(Id), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}