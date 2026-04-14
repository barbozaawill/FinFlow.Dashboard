namespace FinFlow.Dashboard.Entities;

public class Payment
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    public PaymentMethod Method { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Invoice Invoice { get; set; } = null!;
}
