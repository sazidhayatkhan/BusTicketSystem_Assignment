using BusTicketSystem.Models;

namespace BusTicketSystem.Interfaces;

public interface IBusRepository
{
    void Add(Bus bus);

    List<Bus> GetAll();

    Bus? GetById(Guid busId);

    Bus? GetByCoachNumber(string coachNumber);
}