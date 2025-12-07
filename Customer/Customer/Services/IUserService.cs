using Customer.API;

namespace Customer.Services;

public interface IUserService
{
    Task<bool> TryRegistration(UserRequestData userRequestData);
    Task<bool> Login(UserRequestData userRequestData);
}