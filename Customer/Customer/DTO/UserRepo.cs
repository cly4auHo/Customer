namespace Customer.DTO;

public class UserRepo : IUserRepo
{
    public Task<bool> DoRecord(UserEntity model)
    {
        return null;
    }
}