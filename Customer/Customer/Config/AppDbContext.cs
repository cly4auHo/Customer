using Customer.DTO;
using Microsoft.EntityFrameworkCore;

namespace Customer.Config;

public class AppDbContext (DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
}