using FinFlow.Dashboard.DTOs.Requests;
using FinFlow.Dashboard.DTOs.Responses;

namespace FinFlow.Dashboard.Services.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentResponse>> GetAllAsync();
    Task<PaymentResponse?> GetByIdAsync(Guid id);
    Task<PaymentResponse> CreateAsync(CreatePaymentRequest request);
    Task<PaymentResponse?> UpdateAsync(Guid id, UpdatePaymentRequest request);
    Task<bool> DeleteAsync(Guid id);
}
