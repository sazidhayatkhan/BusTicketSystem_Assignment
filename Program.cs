using BusTicketSystem.Interfaces;
using BusTicketSystem.Repositories;
using BusTicketSystem.Services;
using BusTicketSystem.UI;

IUserRepository userRepository = new UserRepository();
UserService userService = new UserService(userRepository);

var ui = new ConsoleUI(userRepository, userService);

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
            ui.AddUser();
            break;

        case "3":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}