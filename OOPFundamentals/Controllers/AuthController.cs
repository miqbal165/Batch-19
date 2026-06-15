using OOPFundamentals.Dtos.Auths;

using OOPFundamentals.Services;

namespace OOPFundamentals.Controllers;

public class AuthController
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    public void Register(string username, string password)
    {
        var result = _service.Register(new RegisterDto
        {
            Username = username,
            Password = password
        });

        Print(result);
    }

    public void Login(string username, string password)
    {
        var result = _service.Login(new LoginDto
        {
            Username = username,
            Password = password
        });

        Print(result);
    }

    private void Print(object obj)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(obj));
    }
}