using OOPFundamentals.Models;

public interface IUserRepository
{
    User? GetByUsername(string username);
    void Add(User user);
}