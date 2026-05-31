using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Repositories;

public class BusRepository : IBusRepository
{
    private readonly List<Bus> _buses = new();

    public void Add(Bus bus)
    {
        _buses.Add(bus);
    }

    public List<Bus> GetAll()
    {
        return _buses;
    }

    public Bus? GetById(Guid busId)
    {
        return _buses.FirstOrDefault(b => b.BusId == busId);
    }
}