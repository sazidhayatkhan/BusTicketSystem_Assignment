using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly List<Schedule> _schedules = new();

    public void Add(Schedule schedule)
    {
        _schedules.Add(schedule);
    }

    public List<Schedule> GetAll()
    {
        return _schedules;
    }

    public List<Schedule> GetByBusId(Guid busId)
    {
        return _schedules
            .Where(s => s.BusId == busId)
            .ToList();
    }
}