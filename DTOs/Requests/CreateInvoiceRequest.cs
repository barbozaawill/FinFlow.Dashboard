using FinFlow.Dashboard.Entities;

namespace FinFlow.Dashboard.DTOs.Requests;

public class CreateInvoiceRequest
{
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; } = 0;
    public DateTime DueDate { get; set; }
    public string Description { get; set; } = string.Empty;
}
