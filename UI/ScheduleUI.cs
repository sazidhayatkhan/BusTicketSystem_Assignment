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

    public void ShowBusSchedulesById()
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

    public void ShowAllSchedules()
    {
        var schedules = _scheduleService.GetAllSchedules();

        if (schedules.Count == 0)
        {
            Console.WriteLine("No schedules found.");
            return;
        }

        foreach (var schedule in schedules)
        {
            var bus = _busService.GetBusById(schedule.BusId);

            Console.WriteLine("\n=========================");
            Console.WriteLine($"Schedule ID: {schedule.ScheduleId}");

            Console.WriteLine("\nBus Information");
            Console.WriteLine($"Coach Number: {bus.CoachNumber}");
            Console.WriteLine($"Bus Type: {bus.BusType}");
            Console.WriteLine($"Total Seats: {bus.TotalSeats}");

            Console.WriteLine("\nRoute Information");
            Console.WriteLine($"From: {schedule.DepartureCity}");
            Console.WriteLine($"To: {schedule.ArrivalCity}");
            Console.WriteLine($"Departure: {schedule.DepartureTime}");
            Console.WriteLine($"Ticket Price: {schedule.TicketPrice}");
        }
    }


}