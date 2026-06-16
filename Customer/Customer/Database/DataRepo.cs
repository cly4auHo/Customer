using Customer.Config;
using Microsoft.EntityFrameworkCore;

namespace Customer.DTO;

public class DataRepo(AppDbContextFactory dbContextFactory) : IDataRepo
{
    public async Task<bool> AddUser(User user)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        
        dbContext.Users.Add(user);
        
        try
        {
            var result = await dbContext.SaveChangesAsync();
            
            return result == 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> IsUserExist(User user)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        
        return await dbContext.Users.AnyAsync(u => u.Email == user.Email && u.Password == user.Password);
    }

    public async Task<bool> IsEmailUsed(string email)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        
        return await dbContext.Users.AnyAsync(u => u.Email == email);
    }
}