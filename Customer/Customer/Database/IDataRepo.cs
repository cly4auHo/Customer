namespace Customer.DTO;

public interface IDataRepo
{
    Task<bool> AddUser(User user);
    Task<bool> IsUserExist(User user);
    Task<bool> IsEmailUsed(string email);
}