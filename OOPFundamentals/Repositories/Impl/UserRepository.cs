using OOPFundamentals.Models;

namespace OOPFundamentals.Repositories.Impl;

public class UserRepository : IUserRepository
{
    private List<User> _users = new();
    private int _id = 1;
    public void Add(User user)
    {
        user.Id =  _id++;
        _users.Add(user);
    }

    public User? GetByUsername(string username)
    {
        return _users.FirstOrDefault(x => x.Username == username);
    }
}