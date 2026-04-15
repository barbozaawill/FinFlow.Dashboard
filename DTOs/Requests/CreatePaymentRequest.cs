using FinFlow.Dashboard.Entities;

namespace FinFlow.Dashboard.DTOs.Requests;

public class CreatePaymentRequest
{
    public Guid InvoiceId { get; set; }
    public decimal AmountPaid { get; set; }
    public PaymentMethod Method { get; set; }

}
