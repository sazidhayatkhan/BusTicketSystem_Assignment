using BusTicketSystem.Enums;
using BusTicketSystem.Services;

namespace BusTicketSystem.UI;

public class BusUI
{
    private readonly BusService _busService;

    public BusUI(BusService busService)
    {
        _busService = busService;
    }

    public void AddBus()
    {
        try
        {
            Console.Write("Enter Coach Number: ");
            var coach = Console.ReadLine();

            Console.Write("Enter Bus Type (1 = Economy, 2 = Business): ");
            var typeInput = Console.ReadLine();

            var type = typeInput == "2"
                ? BusType.BUSINESS
                : BusType.ECONOMY;

            var bus = _busService.CreateBus(coach, type);

            Console.WriteLine($"\nBus created successfully! ID: {bus.BusId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ShowAllBuses()
    {
        var buses = _busService.GetAllBuses();

        if (buses.Count == 0)
        {
            Console.WriteLine("No buses found.");
            return;
        }

        foreach (var bus in buses)
        {
            Console.WriteLine($"\nBus ID: {bus.BusId}");
            Console.WriteLine($"Coach: {bus.CoachNumber}");
            Console.WriteLine($"Type: {bus.BusType}");
            Console.WriteLine($"Total Seats: {bus.TotalSeats}");
            Console.WriteLine($"Available: {bus.GetAvailableSeats()}");
            Console.WriteLine($"Booked: {bus.GetBookedSeats()}");
        }
    }
}