using BusTicketSystem.Interfaces;
using BusTicketSystem.Repositories;
using BusTicketSystem.Services;

namespace BusTicketSystem.UI;

public class InvoiceUI
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IBusRepository _busRepository;

    public InvoiceUI(
    IInvoiceRepository invoiceRepository,
    IUserRepository userRepository,
    ITicketRepository ticketRepository,
    IScheduleRepository scheduleRepository,
    IBusRepository busRepository)
    {
        _invoiceRepository = invoiceRepository;
        _userRepository = userRepository;
        _ticketRepository = ticketRepository;
        _scheduleRepository = scheduleRepository;
        _busRepository = busRepository;
    }

    public void ShowAllInvoices()
    {
        var invoices = _invoiceRepository.GetAll();

        if (invoices.Count == 0)
        {
            Console.WriteLine("No invoices found.");
            return;
        }

        foreach (var i in invoices)
        {
            var ticket = _ticketRepository.GetById(i.TicketId);
            var user = _userRepository.GetById(i.UserId);
            var schedule = _scheduleRepository.GetById(i.ScheduleId);
            var bus = _busRepository.GetById(schedule.BusId);

            Console.WriteLine("\n==============================");
            Console.WriteLine($"Invoice ID: {i.InvoiceId}");
            Console.WriteLine($"Date: {i.GeneratedAt}");

            Console.WriteLine("\n--- USER INFO ---");
            Console.WriteLine($"Name: {user.FullName}");
            Console.WriteLine($"Mobile: {user.MobileNumber}");
            Console.WriteLine($"Email: {user.Email}");

            Console.WriteLine("\n--- TRAVEL INFO ---");
            Console.WriteLine($"From: {schedule.DepartureCity}");
            Console.WriteLine($"To: {schedule.ArrivalCity}");
            Console.WriteLine($"Departure: {schedule.DepartureTime}");
            Console.WriteLine($"Coach: {bus.CoachNumber}");
            Console.WriteLine($"Bus Type: {bus.BusType}");

            Console.WriteLine("\n--- TICKET INFO ---");
            Console.WriteLine($"Seat Number: {ticket.SeatNumber}");
            Console.WriteLine($"Amount Paid: {i.Amount}");

            Console.WriteLine("\n==============================");
        }
    }
}