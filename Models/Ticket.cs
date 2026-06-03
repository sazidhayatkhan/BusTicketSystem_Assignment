namespace BusTicketSystem.Models;

public class Ticket
{
    public Guid TicketId { get; private set; }

    public Guid UserId { get; private set; }

    public Guid ScheduleId { get; private set; }

    public int SeatNumber { get; private set; }

    public DateTime BookingDate { get; private set; }

    public Ticket(
        Guid userId,
        Guid scheduleId,
        int seatNumber)
    {
        TicketId = Guid.NewGuid();

        UserId = userId;
        ScheduleId = scheduleId;
        SeatNumber = seatNumber;

        BookingDate = DateTime.Now;
    }
}