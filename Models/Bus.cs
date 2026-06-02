using BusTicketSystem.Enums;

namespace BusTicketSystem.Models;

public class Bus
{
    public Guid BusId { get; private set; }

    public string CoachNumber { get; private set; }

    public BusType BusType { get; private set; }

    public int TotalSeats { get; private set; }

    public List<Seat> Seats { get; private set; }

    public Bus(string coachNumber, BusType busType)
    {
        BusId = Guid.NewGuid();
        CoachNumber = coachNumber;
        BusType = busType;

        TotalSeats = busType == BusType.BUSINESS ? 27 : 40;

        Seats = GenerateSeats(TotalSeats);
    }

    private List<Seat> GenerateSeats(int totalSeats)
    {
        var seats = new List<Seat>();

        for (int i = 1; i <= totalSeats; i++)
        {
            seats.Add(new Seat(i));
        }

        return seats;
    }

    public int GetAvailableSeats()
    {
        return Seats.Count(s => !s.IsBooked);
    }

    public int GetBookedSeats()
    {
        return Seats.Count(s => s.IsBooked);
    }
}