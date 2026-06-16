using System.Security.Cryptography;
using System.Text;
using Customer.DTO;

namespace Customer.Services;

public class AuthService(IDataRepo dataRepo) : IAuthService
{
    private const string SALT = "SALT";
    
    public async Task<bool> IsUserExist(LoginDto model)
    {
        var user = new User
        {
            Email = model.Email,
            Password = ComputeSha256(model.Password)
        };
        
        return await dataRepo.IsUserExist(user);
    }

    public async Task<bool> AddUser(LoginDto model)
    {
        var user = new User
        {
            Email = model.Email,
            Password = ComputeSha256(model.Password)
        };
        
        return await dataRepo.AddUser(user);
    }

    public async Task<bool> IsEmailUsed(LoginDto model)
    {
        return await dataRepo.IsEmailUsed(ComputeSha256(model.Email));
    }
    
    private string ComputeSha256(string input)
    {
        using var sha256 = SHA256.Create();

        var inputBytes = Encoding.UTF8.GetBytes(input + SALT);
        var hashBytes = sha256.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes); 
    }
}