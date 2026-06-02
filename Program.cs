using BusTicketSystem.Interfaces;
using BusTicketSystem.Repositories;
using BusTicketSystem.Services;
using BusTicketSystem.UI;

IUserRepository userRepository = new UserRepository();
IBusRepository busRepository = new BusRepository();

UserService userService = new UserService(userRepository);
BusService busService = new BusService(busRepository);

var ui = new ConsoleUI(
    userRepository,
    userService,
    busRepository,
    busService);

while (true)
{
    Console.WriteLine("\n=== Bus Ticket System ===");
    Console.WriteLine("1. See all users");
    Console.WriteLine("2. Add user");
    Console.WriteLine("3. Add Bus");
    Console.WriteLine("4. View Buses");
    Console.WriteLine("5. Exit");
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
            ui.AddBus();
            break;

        case "4":
            ui.ShowAllBuses();
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}