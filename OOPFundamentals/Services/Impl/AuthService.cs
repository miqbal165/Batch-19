using OOPFundamentals.Dtos;
using OOPFundamentals.Dtos.Auths;
using OOPFundamentals.Models;
using OOPFundamentals.Utils.Mappers;

namespace OOPFundamentals.Services.Impl;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repo;

    public AuthService(IUserRepository repo)
    {
        _repo = repo;
    }

    public CommonResponse<AuthResponseDto> Login(LoginDto dto)
    {
        User? user = _repo.GetByUsername(dto.Username);
        if (user == null || user.Password != dto.Password)
        {
            return CommonResponse<AuthResponseDto>.Fail("Invalid Credentials");
        }

        AuthResponseDto dataResponse = UserMapper.ToDto(user);

        return CommonResponse<AuthResponseDto>.Ok(dataResponse, "Login Success");
    }

    public CommonResponse<AuthResponseDto> Register(RegisterDto dto)
    {
        User? user = _repo.GetByUsername(dto.Username);
        if (user == null)
        {
            return CommonResponse<AuthResponseDto>.Fail("User already exits");
        }

        User newUser = new()
        {
          Username = dto.Username,
          Password = dto.Password,
          Role = Role.User  
        };

        return CommonResponse<AuthResponseDto>.Ok(UserMapper.ToDto(newUser), "Register Success");
    }
}