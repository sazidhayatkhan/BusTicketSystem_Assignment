namespace BusTicketSystem.Models;

public class Seat
{
    public int SeatNumber { get; private set; }

    public bool IsBooked { get; private set; }

    public Seat(int seatNumber)
    {
        SeatNumber = seatNumber;
        IsBooked = false;
    }

    public void Book()
    {
        if (IsBooked)
            throw new Exception("Seat already booked");

        IsBooked = true;
    }

    public void Release()
    {
        IsBooked = false;
    }
}