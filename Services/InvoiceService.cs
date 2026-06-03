using BusTicketSystem.Interfaces;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services;

public class InvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IScheduleRepository _scheduleRepository;

    public InvoiceService(
        IInvoiceRepository invoiceRepository,
        IScheduleRepository scheduleRepository)
    {
        _invoiceRepository = invoiceRepository;
        _scheduleRepository = scheduleRepository;
    }

    public Invoice GenerateInvoice(Ticket ticket)
    {
        var schedule = _scheduleRepository.GetById(ticket.ScheduleId);

        var invoice = new Invoice(
            ticket.TicketId,
            ticket.UserId,
            ticket.ScheduleId,
            ticket.SeatNumber,
            schedule.TicketPrice
        );

        _invoiceRepository.Add(invoice);

        return invoice;
    }
}