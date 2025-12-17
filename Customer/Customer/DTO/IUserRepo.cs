namespace Customer.DTO;

public interface IUserRepo
{
    Task<bool> DoRecord(UserEntity model); 
    Task<UserEntity> GetUser(UserEntity model); 
}