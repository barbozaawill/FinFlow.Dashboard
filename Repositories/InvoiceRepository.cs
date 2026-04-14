using Microsoft.EntityFrameworkCore;
using FinFlow.Dashboard.Data;
using FinFlow.Dashboard.Entities;
using FinFlow.Dashboard.Repositories.Interfaces;

namespace DebtFlow.Api.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _context.Invoices.ToListAsync();
    }

    public async Task<Invoice?> GetByIdAsync(Guid id)
    {
        return await _context.Invoices.FindAsync(id);
    }

    public async Task<Invoice> CreateAsync(Invoice entity)
    {
        _context.Invoices.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Invoice> UpdateAsync(Invoice entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Invoices.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Invoices.FindAsync(id);
        if (entity is null) return false;
        _context.Invoices.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}