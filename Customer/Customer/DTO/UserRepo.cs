using Customer.Config;

namespace Customer.DTO;

public class UserRepo(AppDbContextFactory dbContextFactory) : IUserRepo
{
    public async Task<bool> DoRecord(UserEntity model)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        
        dbContext.Users.Add(model);

        try
        {
            var result = await dbContext.SaveChangesAsync();
            
            return result == 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.InnerException?.Message ?? e.Message);
            
            return false;
        }
    }

    public async Task<UserEntity> GetUser(UserEntity model)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        
        return null;
    }
}