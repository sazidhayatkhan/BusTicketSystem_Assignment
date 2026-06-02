using BusTicketSystem.Interfaces;
using BusTicketSystem.Services;

namespace BusTicketSystem.UI;

public class UserUI
{
    private readonly IUserRepository _userRepository;
    private readonly UserService _userService;

    public UserUI(IUserRepository userRepository, UserService userService)
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

        foreach (var user in users)
        {
            Console.WriteLine($"\nID: {user.UserId}");
            Console.WriteLine($"Name: {user.FullName}");
            Console.WriteLine($"Mobile: {user.MobileNumber}");
            Console.WriteLine($"Email: {user.Email}");
        }
    }

    public void AddUser()
    {
        try
        {
            Console.Write("Enter Full Name: ");
            var name = Console.ReadLine();

            Console.Write("Enter Mobile Number: ");
            var mobile = Console.ReadLine();

            Console.Write("Enter Email: ");
            var email = Console.ReadLine();

            var user = _userService.RegisterUser(name, mobile, email);

            Console.WriteLine($"\nUser created! ID: {user.UserId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}