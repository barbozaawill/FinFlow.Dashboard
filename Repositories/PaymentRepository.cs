using FinFlow.Dashboard.Data;
using FinFlow.Dashboard.Data;
using FinFlow.Dashboard.Entities;
using FinFlow.Dashboard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Dashboard.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        return await _context.Payments.FindAsync(id);
    }

    public async Task<Payment> CreateAsync(Payment entity)
    {
        _context.Payments.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Payment> UpdateAsync(Payment entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Payments.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Payments.FindAsync(id);
        if (entity is null) return false;
        _context.Payments.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
