using BusTicketSystem.Interfaces;
using BusTicketSystem.Repositories;
using BusTicketSystem.Services;
using BusTicketSystem.UI;

IUserRepository userRepository = new UserRepository();
IBusRepository busRepository = new BusRepository();
IScheduleRepository scheduleRepository = new ScheduleRepository();
ITicketRepository ticketRepository = new TicketRepository();
IInvoiceRepository invoiceRepository = new InvoiceRepository();

UserService userService = new UserService(userRepository);
BusService busService = new BusService(busRepository);

ScheduleService scheduleService = new ScheduleService(
    scheduleRepository,
    busRepository
);

InvoiceService invoiceService = new InvoiceService(
    invoiceRepository,
    scheduleRepository
);

TicketService ticketService = new TicketService(
    userRepository,
    scheduleRepository,
    ticketRepository,
    invoiceService
);

// Seed demo data
BusTicketSystem.DemoData.Seed(
    userService,
    busService,
    scheduleService,
    ticketService,
    invoiceService
);

var userUI = new UserUI(userRepository, userService);
var busUI = new BusUI(busService);
var scheduleUI = new ScheduleUI(scheduleService, busService);

var ticketUI = new TicketUI(
    ticketService,
    userRepository,
    scheduleRepository
);

var invoiceUI = new InvoiceUI(
    invoiceRepository,
    userRepository,
    ticketRepository,
    scheduleRepository,
    busRepository
);

while (true)
{
    Console.WriteLine("\n=== Bus Ticket System ===");
    Console.WriteLine("1. See all users");
    Console.WriteLine("2. Add user");
    Console.WriteLine("3. Add Bus");
    Console.WriteLine("4. View Buses");
    Console.WriteLine("5. Add Schedule");
    Console.WriteLine("6. See All Schedules");
    Console.WriteLine("7. View Schedule of Bus");
    Console.WriteLine("8. Book Ticket");
    Console.WriteLine("9. View User Tickets");
    Console.WriteLine("10. View Schedule Tickets");
    Console.WriteLine("11. View Invoices");
    Console.WriteLine("12. Exit");
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
            scheduleUI.AddSchedule();
            break;

        case "6":
            scheduleUI.ShowAllSchedules();
            break;

        case "7":
            scheduleUI.ShowBusSchedulesById();
            break;

        case "8":
            ticketUI.BookTicket();
            break;

        case "9":
            ticketUI.ShowUserTickets();
            break;

        case "10":
            ticketUI.ShowScheduleTickets();
            break;

        case "11":
            invoiceUI.ShowAllInvoices();
            break;

        case "12":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}