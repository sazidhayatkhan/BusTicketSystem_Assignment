namespace BusTicketSystem.Models;

public class Schedule
{
    public Guid ScheduleId { get; private set; }

    public Guid BusId { get; private set; }

    public string DepartureCity { get; private set; }

    public string ArrivalCity { get; private set; }

    public DateTime DepartureTime { get; private set; }

    public decimal TicketPrice { get; private set; }

    public List<Ticket> Tickets { get; private set; } = new();

    public void AddTicket(Ticket ticket)
    {
        Tickets.Add(ticket);
    }

    public Schedule(
        Guid busId,
        string departureCity,
        string arrivalCity,
        DateTime departureTime,
        decimal ticketPrice)
    {
        ScheduleId = Guid.NewGuid();
        BusId = busId;

        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        DepartureTime = departureTime;
        TicketPrice = ticketPrice;
    }
}