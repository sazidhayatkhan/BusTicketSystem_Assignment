using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly List<Ticket> _tickets = new();

    public void Add(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public List<Ticket> GetAll()
    {
        return _tickets;
    }

    public List<Ticket> GetByUser(Guid userId)
    {
        return _tickets
            .Where(t => t.UserId == userId)
            .ToList();
    }

    public List<Ticket> GetBySchedule(Guid scheduleId)
    {
        return _tickets
            .Where(t => t.ScheduleId == scheduleId)
            .ToList();
    }

    public Ticket GetById(Guid id)
    {
        return _tickets.FirstOrDefault(t => t.TicketId == id)
            ?? throw new Exception("Ticket not found");
    }
}