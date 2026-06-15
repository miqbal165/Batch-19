using OOPFundamentals.Dtos;
using OOPFundamentals.Dtos.Auths;

namespace OOPFundamentals.Services;

public interface IAuthService
{
    CommonResponse<AuthResponseDto> Register(RegisterDto dto);
    CommonResponse<AuthResponseDto> Login(LoginDto dto);
}