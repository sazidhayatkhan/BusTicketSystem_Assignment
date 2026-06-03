using BusTicketSystem.Services;
using BusTicketSystem.Interfaces;

namespace BusTicketSystem.UI;

public class TicketUI
{
    private readonly TicketService _ticketService;
    private readonly IUserRepository _userRepository;
    private readonly IScheduleRepository _scheduleRepository;

    public TicketUI(
        TicketService ticketService,
        IUserRepository userRepository,
        IScheduleRepository scheduleRepository)
    {
        _ticketService = ticketService;
        _userRepository = userRepository;
        _scheduleRepository = scheduleRepository;
    }

    public void BookTicket()
    {
        try
        {
            Console.WriteLine("\n--- Book Ticket ---");

            Console.WriteLine("\nAvailable Users:");
            foreach (var user in _userRepository.GetAll())
            {
                Console.WriteLine($"ID: {user.UserId} | {user.FullName}");
            }

            Console.Write("\nEnter User ID: ");
            var userId = Guid.Parse(Console.ReadLine());

            Console.WriteLine("\nAvailable Schedules:");
            foreach (var schedule in _scheduleRepository.GetAll())
            {
                Console.WriteLine($"ID: {schedule.ScheduleId} | {schedule.DepartureCity} → {schedule.ArrivalCity}");
            }

            Console.Write("\nEnter Schedule ID: ");
            var scheduleId = Guid.Parse(Console.ReadLine());

            Console.Write("Enter Seat Number: ");
            var seatNumber = int.Parse(Console.ReadLine());

            var ticket = _ticketService.BookTicket(userId, scheduleId, seatNumber);

            Console.WriteLine($"\nTicket Booked Successfully!");
            Console.WriteLine($"Ticket ID: {ticket.TicketId}");
            Console.WriteLine($"Seat Number: {ticket.SeatNumber}");
            Console.WriteLine($"Booking Date: {ticket.BookingDate}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ShowUserTickets()
    {
        try
        {
            Console.WriteLine("\n--- User Tickets ---");

            Console.WriteLine("Available Users:");
            foreach (var user in _userRepository.GetAll())
            {
                Console.WriteLine($"ID: {user.UserId} | {user.FullName}");
            }

            Console.Write("\nEnter User ID: ");
            var userId = Guid.Parse(Console.ReadLine());

            var tickets = _ticketService.GetTicketsByUser(userId);

            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets found.");
                return;
            }

            foreach (var t in tickets)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"Ticket ID: {t.TicketId}");
                Console.WriteLine($"Schedule ID: {t.ScheduleId}");
                Console.WriteLine($"Seat Number: {t.SeatNumber}");
                Console.WriteLine($"Booking Date: {t.BookingDate}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ShowScheduleTickets()
    {
        try
        {
            Console.WriteLine("\n--- Schedule Tickets ---");

            Console.WriteLine("Available Schedules:");
            foreach (var schedule in _scheduleRepository.GetAll())
            {
                Console.WriteLine($"ID: {schedule.ScheduleId} | {schedule.DepartureCity} → {schedule.ArrivalCity} | {schedule.DepartureTime}");
            }

            Console.Write("\nEnter Schedule ID: ");
            var scheduleId = Guid.Parse(Console.ReadLine());

            var tickets = _ticketService.GetTicketsBySchedule(scheduleId);

            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets found.");
                return;
            }

            foreach (var t in tickets)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"Ticket ID: {t.TicketId}");
                Console.WriteLine($"User ID: {t.UserId}");
                Console.WriteLine($"Seat Number: {t.SeatNumber}");
                Console.WriteLine($"Booking Date: {t.BookingDate}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}