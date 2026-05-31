namespace BusTicketSystem.Models;

public class User
{
    public Guid UserId { get; private set; }

    public string FullName { get; private set; }

    public string MobileNumber { get; private set; }

    public string Email { get; private set; }

    public List<Ticket> BookedTickets { get; private set; }

    public User(
        string fullName,
        string mobileNumber,
        string email)
    {
        UserId = Guid.NewGuid();

        FullName = fullName;
        MobileNumber = mobileNumber;
        Email = email;

        BookedTickets = new List<Ticket>();
    }

    public void AddTicket(Ticket ticket)
    {
        BookedTickets.Add(ticket);
    }
}