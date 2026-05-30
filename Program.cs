using BusTicketSystem.Interfaces;
using BusTicketSystem.Repositories;
using BusTicketSystem.Services;
using BusTicketSystem.UI;

IUserRepository userRepository = new UserRepository();
UserService userService = new UserService(userRepository);

var ui = new ConsoleUI(userRepository);

while (true)
{
    Console.WriteLine("\n=== Bus Ticket System ===");
    Console.WriteLine("1. See all users");
    Console.WriteLine("2. Add user");
    Console.WriteLine("3. Exit");
    Console.Write("Select option: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            ui.SeeAllUsers();
            break;

        case "2":
            AddUser(userService);
            break;

        case "3":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

void AddUser(UserService userService)
{
    Console.Write("Enter Full Name: ");
    var name = Console.ReadLine();

    Console.Write("Enter Mobile Number: ");
    var mobile = Console.ReadLine();

    Console.Write("Enter Email: ");
    var email = Console.ReadLine();

    try
    {
        var user = userService.RegisterUser(name, mobile, email);

        Console.WriteLine("\nUser created successfully!");
        Console.WriteLine($"User ID: {user.UserId}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}