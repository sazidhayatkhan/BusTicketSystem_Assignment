using BusTicketSystem.Models;

namespace BusTicketSystem.Interfaces;

public interface IInvoiceRepository
{
    void Add(Invoice invoice);

    List<Invoice> GetAll();

    Invoice GetByTicketId(Guid ticketId);
}