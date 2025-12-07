using Microsoft.EntityFrameworkCore;

namespace Customer.DTO;

[Index(nameof(Id), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}