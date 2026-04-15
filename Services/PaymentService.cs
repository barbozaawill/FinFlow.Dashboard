using AutoMapper;
using FinFlow.Dashboard.DTOs.Requests;
using FinFlow.Dashboard.DTOs.Responses;
using FinFlow.Dashboard.Entities;
using FinFlow.Dashboard.Repositories;
using FinFlow.Dashboard.Repositories.Interfaces;
using FinFlow.Dashboard.Services.Interfaces;

namespace FinFlow.Dashboard.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    public async Task<PaymentResponse> CreateAsync(CreatePaymentRequest request)
    {
        var payment = _mapper.Map<Payment>(request);
        var createdPayment = await _paymentRepository.CreateAsync(payment);
        return _mapper.Map<PaymentResponse>(createdPayment);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _paymentRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PaymentResponse>> GetAllAsync()
    {
        var payment = await _paymentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PaymentResponse>>(payment);
    }

    public async Task<PaymentResponse?> GetByIdAsync(Guid id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);
        if (payment == null) return null;
        return _mapper.Map<PaymentResponse>(payment);
    }

    public async Task<PaymentResponse?> UpdateAsync(Guid id, UpdatePaymentRequest request)
    {
        var existingPayment = await _paymentRepository.GetByIdAsync(id);
        if (existingPayment == null) return null;
        _mapper.Map(request, existingPayment);
        var updatedPayment = await _paymentRepository.UpdateAsync(existingPayment);
        return _mapper.Map<PaymentResponse>(updatedPayment);
    }
}
