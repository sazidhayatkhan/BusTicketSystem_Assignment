using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services;

public class TicketService
{
    private readonly IUserRepository _userRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly ITicketRepository _ticketRepository;

    public TicketService(
        IUserRepository userRepository,
        IScheduleRepository scheduleRepository,
        ITicketRepository ticketRepository)
    {
        _userRepository = userRepository;
        _scheduleRepository = scheduleRepository;
        _ticketRepository = ticketRepository;
    }

    public Ticket BookTicket(Guid userId, Guid scheduleId, int seatNumber)
    {

        var user = _userRepository.GetById(userId);
        if (user == null)
            throw new Exception("User not found");

        // Validate Schedule
        var schedule = _scheduleRepository.GetById(scheduleId);
        if (schedule == null)
            throw new Exception("Schedule not found");

        // Validate Seat Number
        if (seatNumber <= 0)
            throw new Exception("Invalid seat number");

        var seatTaken = schedule.Tickets.Any(t => t.SeatNumber == seatNumber);

        if (seatTaken)
            throw new Exception("Seat already booked for this schedule");

        var ticket = new Ticket(userId, scheduleId, seatNumber);

        _ticketRepository.Add(ticket);

        schedule.AddTicket(ticket);

        user.AddTicket(ticket);

        return ticket;
    }

    public List<Ticket> GetTicketsByUser(Guid userId)
    {
        return _ticketRepository.GetByUser(userId);
    }

    public List<Ticket> GetTicketsBySchedule(Guid scheduleId)
    {
        return _ticketRepository.GetBySchedule(scheduleId);
    }
}