
using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }

    public void Add(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(Guid userId)
    {
        return _users.FirstOrDefault(u => u.UserId == userId);
    }

    public User? GetByMobileNumber(string mobileNumber)
    {
        return _users.FirstOrDefault(
            u => u.MobileNumber.Equals(
                mobileNumber,
                StringComparison.OrdinalIgnoreCase));
    }
}