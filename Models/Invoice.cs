namespace BusTicketSystem.Models;

public class Invoice
{
    public Guid InvoiceId { get; private set; }

    public Guid TicketId { get; private set; }

    public Guid UserId { get; private set; }

    public Guid ScheduleId { get; private set; }

    public int SeatNumber { get; private set; }

    public decimal Amount { get; private set; }

    public DateTime GeneratedAt { get; private set; }

    public Invoice(
        Guid ticketId,
        Guid userId,
        Guid scheduleId,
        int seatNumber,
        decimal amount)
    {
        InvoiceId = Guid.NewGuid();
        TicketId = ticketId;
        UserId = userId;
        ScheduleId = scheduleId;
        SeatNumber = seatNumber;
        Amount = amount;
        GeneratedAt = DateTime.Now;
    }
}