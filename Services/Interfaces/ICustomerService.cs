using FinFlow.Dashboard.DTOs.Requests;
using FinFlow.Dashboard.DTOs.Responses;

namespace FinFlow.Dashboard.Services.Interfaces;

public class ICustomerService
{
    Task<IEnumerable<CustomerResponse>> GetAllAsync();
    Task<CustomerResponse?> GetByIdAsync(Guid id);
}
