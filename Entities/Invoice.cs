namespace FinFlow.Dashboard.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public InvoiceStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Customer Customer { get; set; } = null!;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
