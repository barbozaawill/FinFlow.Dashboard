using FinFlow.Dashboard.Services.Interfaces;
using AutoMapper;
using FinFlow.Dashboard.Repositories.Interfaces;
using FinFlow.Dashboard.Entities;
using FinFlow.Dashboard.DTOs.Requests;
using FinFlow.Dashboard.DTOs.Responses;

namespace FinFlow.Dashboard.Services; 

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    
    public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);
        var createdCustomer = await _customerRepository.CreateAsync(customer);
        return _mapper.Map<CustomerResponse>(createdCustomer);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _customerRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerResponse>>(customers);
    }

    public async Task<CustomerResponse?> GetByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null) return null;
        return _mapper.Map<CustomerResponse>(customer);
    }

    public async Task<CustomerResponse?> UpdateAsync(Guid id, UpdateCustomerRequest request)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(id);
        if (existingCustomer == null) return null;
        _mapper.Map(request, existingCustomer);
        var updatedCustomer = await _customerRepository.UpdateAsync(existingCustomer);
        return _mapper.Map<CustomerResponse>(updatedCustomer);
    }

}
