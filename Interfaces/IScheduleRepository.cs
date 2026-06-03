using BusTicketSystem.Models;

namespace BusTicketSystem.Interfaces;

public interface IScheduleRepository
{
    void Add(Schedule schedule);

    List<Schedule> GetAll();

    List<Schedule> GetByBusId(Guid busId);

    Schedule GetById(Guid scheduleId);
}