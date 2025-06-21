using Jobsy.Recruiter.Domain.Model.Aggregates;
using Jobsy.Recruiter.Domain.Repository;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Recruiter.Infrastructure.Repositories;

public class EmployerProfileRepository : IEmployerProfileRepository
{
    private readonly AppDbContext _context;

    public EmployerProfileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(EmployerProfile employerProfile)
    {
        await _context.Set<EmployerProfile>().AddAsync(employerProfile);
    }

    public async Task<bool> ExistsByUserIdAsync(int idUsuario)
    {
        return await _context.Set<EmployerProfile>().AnyAsync(p => p.Id_Usuario == idUsuario);
    }
    
    // --- AÑADIR ESTAS 3 IMPLEMENTACIONES ---
    public async Task<EmployerProfile?> FindByIdAsync(int id)
    {
        return await _context.Set<EmployerProfile>().FindAsync(id);
    }

    public void Update(EmployerProfile employerProfile)
    {
        _context.Set<EmployerProfile>().Update(employerProfile);
    }

    public void Remove(EmployerProfile employerProfile)
    {
        _context.Set<EmployerProfile>().Remove(employerProfile);
    }
}