using BusTicketSystem.Interfaces;
using BusTicketSystem.Repositories;
using BusTicketSystem.Services;
using BusTicketSystem.UI;

IUserRepository userRepository = new UserRepository();
IBusRepository busRepository = new BusRepository();

UserService userService = new UserService(userRepository);
BusService busService = new BusService(busRepository);

var userUI = new UserUI(userRepository, userService);
var busUI = new BusUI(busService);

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
            userUI.SeeAllUsers();
            break;

        case "2":
            userUI.AddUser();
            break;

        case "3":
            busUI.AddBus();
            break;

        case "4":
            busUI.ShowAllBuses();
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}