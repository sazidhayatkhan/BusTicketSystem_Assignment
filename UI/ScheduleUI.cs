using BusTicketSystem.Services;

namespace BusTicketSystem.UI;

public class ScheduleUI
{
    private readonly ScheduleService _scheduleService;
    private readonly BusService _busService;

    public ScheduleUI(ScheduleService scheduleService, BusService busService)
    {
        _scheduleService = scheduleService;
        _busService = busService;
    }

    public void AddSchedule()
    {
        try
        {
            Console.Write("Enter Bus ID: ");
            var busId = Guid.Parse(Console.ReadLine());

            Console.Write("Departure City: ");
            var from = Console.ReadLine();

            Console.Write("Arrival City: ");
            var to = Console.ReadLine();

            Console.Write("Departure Date (yyyy-mm-dd hh:mm): ");
            var time = DateTime.Parse(Console.ReadLine());

            Console.Write("Ticket Price: ");
            var price = decimal.Parse(Console.ReadLine());

            var schedule = _scheduleService.CreateSchedule(
                busId, from, to, time, price);

            Console.WriteLine($"\nSchedule created! ID: {schedule.ScheduleId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ShowBusSchedules()
    {
        Console.Write("Enter Bus ID: ");
        var busId = Guid.Parse(Console.ReadLine());

        var schedules = _scheduleService.GetSchedulesByBus(busId);

        if (schedules.Count == 0)
        {
            Console.WriteLine("No schedules found.");
            return;
        }

        foreach (var s in schedules)
        {
            Console.WriteLine($"\nSchedule ID: {s.ScheduleId}");
            Console.WriteLine($"From: {s.DepartureCity}");
            Console.WriteLine($"To: {s.ArrivalCity}");
            Console.WriteLine($"Time: {s.DepartureTime}");
            Console.WriteLine($"Price: {s.TicketPrice}");
        }
    }

    
}