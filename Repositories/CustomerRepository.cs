using Microsoft.EntityFrameworkCore;
using FinFlow.Dashboard.Data;
using FinFlow.Dashboard.Entities;
using FinFlow.Dashboard.Repositories.Interfaces;

namespace DebtFlow.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> CreateAsync(Customer entity)
    {
        _context.Customers.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Customer> UpdateAsync(Customer entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Customers.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Customers.FindAsync(id);
        if (entity is null) return false;
        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}