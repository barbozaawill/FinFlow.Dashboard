using FinFlow.Dashboard.Entities;

namespace FinFlow.Dashboard.DTOs.Requests;

public class CreateCustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public CustomerType CustomerType { get; set; }
}


