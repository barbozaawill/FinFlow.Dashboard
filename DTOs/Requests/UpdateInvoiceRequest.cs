using FinFlow.Dashboard.Entities;

namespace FinFlow.Dashboard.DTOs.Requests;

public class UpdateInvoiceRequest
{
    public decimal Amount { get; set; }
    public InvoiceStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
}
