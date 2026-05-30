using BusTicketSystem.Models;

namespace BusTicketSystem.Interfaces;

public interface IUserRepository
{
    void Add(User user);

    User GetById(Guid userId);

    List<User> GetAll();

    User GetByMobileNumber(string mobileNumber);
}