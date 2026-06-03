using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;
using BusTicketSystem.Enums;

namespace BusTicketSystem.Services;

public class BusService
{
    private readonly IBusRepository _busRepository;

    public BusService(IBusRepository busRepository)
    {
        _busRepository = busRepository;
    }

    public Bus CreateBus(string coachNumber, BusType busType)
    {
        if (string.IsNullOrWhiteSpace(coachNumber))
            throw new Exception("Coach number is required");

        var existingBus = _busRepository.GetByCoachNumber(coachNumber);

        if (existingBus != null)
            throw new Exception("Coach number already exists");

        var bus = new Bus(coachNumber, busType);

        _busRepository.Add(bus);

        return bus;
    }

    public List<Bus> GetAllBuses()
    {
        return _busRepository.GetAll();
    }

    public Bus? GetBusById(Guid busId)
    {
        return _busRepository.GetById(busId);
    }
}