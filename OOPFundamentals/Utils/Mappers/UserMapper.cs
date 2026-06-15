using OOPFundamentals.Dtos.Auths;
using OOPFundamentals.Models;

namespace OOPFundamentals.Utils.Mappers;

public class UserMapper
{
    public static AuthResponseDto ToDto(User user)
    {
        return new AuthResponseDto
        {
            Username = user.Username,
            Role = user.Role
        };
    }
}