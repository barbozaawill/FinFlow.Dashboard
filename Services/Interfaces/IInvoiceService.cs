using FinFlow.Dashboard.DTOs.Requests;
using FinFlow.Dashboard.DTOs.Responses;

namespace FinFlow.Dashboard.Services.Interfaces;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceResponse>> GetAllAsync();
    Task<InvoiceResponse?> GetByIdAsync(Guid id);
    Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request);
    Task<InvoiceResponse?> UpdateAsync(Guid id, UpdateInvoiceRequest request);
    Task<bool> DeleteAsync(Guid id);
}
