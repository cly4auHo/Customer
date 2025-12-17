using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Customer.API;
using Customer.DTO;

namespace Customer.Services;

public class UserService(IUserRepo userRepo, AppSettings appSettings) : IUserService
{
    public async Task<bool> TryRegistration(UserRequestData data)
    {
        if (!IsValidEmail(data.Email) || data.Password.Length < appSettings.MinCountForPassword)
            return false;
        
        try
        {
            var model = new UserEntity
            {
                Email = data.Email,
                Password = ComputeSha256(data.Password)
            };
        
            return await userRepo.DoRecord(model);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Login(UserRequestData data)
    {
        if (!IsValidEmail(data.Email) || data.Password.Length < appSettings.MinCountForPassword)
            return false;

        try
        {
            var model = new UserEntity
            {
                Email = data.Email,
                Password = ComputeSha256(data.Password)
            };
            
            var user = await userRepo.GetUser(model);
            
            return user != null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    private string ComputeSha256(string data)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(data));
        var builder = new StringBuilder();

        foreach (var b in bytes)
            builder.Append(b);

        return builder.ToString();
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var address = new MailAddress(email);
            return address.Address == email;
        }
        catch
        {
            return false;
        }
    }
}