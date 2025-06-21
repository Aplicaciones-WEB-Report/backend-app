using Jobsy.Shared.Domain.Repository;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;

namespace Jobsy.Shared.Infrastructure.Persistencia.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}