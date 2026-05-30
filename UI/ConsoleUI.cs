using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.UI;

public class ConsoleUI
{
    private readonly IUserRepository _userRepository;

    public ConsoleUI(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void SeeAllUsers()
    {
        var users = _userRepository.GetAll();

        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
            return;
        }

        Console.WriteLine("\n--- Users ---");

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.UserId}");
            Console.WriteLine($"Name: {user.FullName}");
            Console.WriteLine($"Mobile: {user.MobileNumber}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine("-------------------");
        }
    }
}