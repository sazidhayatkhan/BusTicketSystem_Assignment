using BusTicketSystem.Interfaces;
using BusTicketSystem.Services;

namespace BusTicketSystem.UI;

public class ConsoleUI
{
    private readonly IUserRepository _userRepository;
    private readonly UserService _userService;

    public ConsoleUI(
        IUserRepository userRepository,
        UserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public void SeeAllUsers()
    {
        var users = _userRepository.GetAll();

        if (users.Count == 0)
        {
            Console.WriteLine("No users found 😭");
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

    public void AddUser()
    {
        Console.Write("Enter Full Name: ");
        var name = Console.ReadLine();

        Console.Write("Enter Mobile Number: ");
        var mobile = Console.ReadLine();

        Console.Write("Enter Email: ");
        var email = Console.ReadLine();

        try
        {
            var user = _userService.RegisterUser(name, mobile, email);

            Console.WriteLine("\nUser created successfully!");
            Console.WriteLine($"User ID: {user.UserId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}