using AutoMapper;
using DebtFlow.Api.Repositories;
using FinFlow.Dashboard.DTOs.Requests;
using FinFlow.Dashboard.DTOs.Responses;
using FinFlow.Dashboard.Entities;
using FinFlow.Dashboard.Repositories.Interfaces;
using FinFlow.Dashboard.Services.Interfaces;

namespace FinFlow.Dashboard.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;

    public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }

    public async Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request)
    {
        var invoice = _mapper.Map<Invoice>(request);
        var createdInvoice = await _invoiceRepository.CreateAsync(invoice);
        return _mapper.Map<InvoiceResponse>(createdInvoice);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _invoiceRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<InvoiceResponse>> GetAllAsync()
    {
        var invoice = await _invoiceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<InvoiceResponse>>(invoice);
    }

    public async Task<InvoiceResponse?> GetByIdAsync(Guid id)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);
        if (invoice == null) return null;
        return _mapper.Map<InvoiceResponse>(invoice);
    }

    public async Task<InvoiceResponse?> UpdateAsync(Guid id, UpdateInvoiceRequest request)
    {
        var existingInvoice = await _invoiceRepository.GetByIdAsync(id);
        if (existingInvoice == null) return null;
        _mapper.Map(request, existingInvoice);
        var updatedInvoice = await _invoiceRepository.UpdateAsync(existingInvoice);
        return _mapper.Map<InvoiceResponse>(updatedInvoice);
    }

}
