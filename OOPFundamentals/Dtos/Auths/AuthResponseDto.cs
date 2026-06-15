using OOPFundamentals.Models;

namespace OOPFundamentals.Dtos.Auths;

public class AuthResponseDto
{
    public string Username { get; set; }
    public Role Role { get; set; }
}