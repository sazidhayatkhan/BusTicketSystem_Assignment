using BusTicketSystem.Models;

namespace BusTicketSystem.Interfaces;

public interface ITicketRepository
{
    void Add(Ticket ticket);

    List<Ticket> GetAll();

    List<Ticket> GetByUser(Guid userId);

    List<Ticket> GetBySchedule(Guid scheduleId);
}