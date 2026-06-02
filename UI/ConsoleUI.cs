using BusTicketSystem.Interfaces;
using BusTicketSystem.Services;
using BusTicketSystem.Enums;
using BusTicketSystem.Repositories;

namespace BusTicketSystem.UI;

public class ConsoleUI
{
    private readonly IUserRepository _userRepository;
    private readonly IBusRepository _busRepository;
    private readonly UserService _userService;
    private readonly BusService _busService;

    public ConsoleUI(
    IUserRepository userRepository,
    UserService userService,
    IBusRepository busRepository,
    BusService busService)
    {
        _userRepository = userRepository;
        _userService = userService;
        _busRepository = busRepository;
        _busService = busService;
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

    public void AddBus()
    {
        try
        {
            Console.Write("Enter Coach Number: ");
            var coach = Console.ReadLine();

            Console.Write("Enter Bus Type (1 = Economy, 2 = Business): ");
            var typeInput = Console.ReadLine();

            var type = typeInput == "2"
                ? BusType.BUSINESS
                : BusType.ECONOMY;

            var bus = _busService.CreateBus(coach, type);

            Console.WriteLine($"\nBus created successfully!");
            Console.WriteLine($"Bus ID: {bus.BusId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ShowAllBuses()
    {
        var buses = _busService.GetAllBuses();

        if (buses.Count == 0)
        {
            Console.WriteLine("No buses found.");
            return;
        }

        foreach (var bus in buses)
        {
            Console.WriteLine($"\nBus ID: {bus.BusId}");
            Console.WriteLine($"Coach: {bus.CoachNumber}");
            Console.WriteLine($"Type: {bus.BusType}");
            Console.WriteLine($"Total Seats: {bus.TotalSeats}");
            Console.WriteLine($"Available: {bus.GetAvailableSeats()}");
            Console.WriteLine($"Booked: {bus.GetBookedSeats()}");
        }
    }
}