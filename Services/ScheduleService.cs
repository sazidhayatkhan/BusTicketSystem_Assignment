using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services;

public class ScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IBusRepository _busRepository;

    public ScheduleService(
        IScheduleRepository scheduleRepository,
        IBusRepository busRepository)
    {
        _scheduleRepository = scheduleRepository;
        _busRepository = busRepository;
    }

    

    public Schedule CreateSchedule(
        Guid busId,
        string from,
        string to,
        DateTime departureTime,
        decimal price)
    {
        var bus = _busRepository.GetById(busId);

        if (bus == null)
            throw new Exception("Bus not found");

        if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            throw new Exception("Cities are required");

        if (price <= 0)
            throw new Exception("Price must be greater than 0");

        var schedule = new Schedule(busId, from, to, departureTime, price);

        _scheduleRepository.Add(schedule);

        bus.AddSchedule(schedule);

        return schedule;
    }

    public List<Schedule> GetSchedulesByBus(Guid busId)
    {
        return _scheduleRepository.GetByBusId(busId);
    }
}