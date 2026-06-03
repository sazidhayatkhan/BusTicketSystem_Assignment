using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly List<Invoice> _invoices = new();

    public void Add(Invoice invoice)
    {
        _invoices.Add(invoice);
    }

    public List<Invoice> GetAll()
    {
        return _invoices;
    }

    public Invoice GetByTicketId(Guid ticketId)
    {
        return _invoices.FirstOrDefault(i => i.TicketId == ticketId)
            ?? throw new Exception("Invoice not found");
    }
}