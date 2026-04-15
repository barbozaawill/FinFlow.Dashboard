using FinFlow.Dashboard.Entities;

namespace FinFlow.Dashboard.DTOs.Requests;

public class UpdatePaymentRequest
{
    public decimal AmountPaid { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    public PaymentMethod Method { get; set; }
}
