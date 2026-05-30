namespace BusTicketSystem.Models;

public class Ticket
{
    public Guid TicketId { get; private set; }

    public string Route { get; private set; }

    public decimal Fare { get; private set; }

    public DateTime BookingTime { get; private set; }

    public Ticket(
        string route,
        decimal fare)
    {
        TicketId = Guid.NewGuid();

        Route = route;
        Fare = fare;

        BookingTime = DateTime.Now;
    }
}