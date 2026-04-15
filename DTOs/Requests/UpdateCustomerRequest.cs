using FinFlow.Dashboard.Entities;

namespace FinFlow.Dashboard.DTOs.Requests;

public class UpdateCustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public CustomerType CustomerType { get; set; }
    public bool IsActive { get; set; }
}
