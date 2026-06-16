using Customer.DTO;

namespace Customer.Services;

public interface IAuthService
{
    Task<bool> IsUserExist(LoginDto model);
    Task<bool> AddUser(LoginDto model);
    Task<bool> IsEmailUsed(LoginDto model);
}