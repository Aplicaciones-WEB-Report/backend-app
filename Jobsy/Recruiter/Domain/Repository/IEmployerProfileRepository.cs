using Jobsy.Recruiter.Domain.Model.Aggregates;

namespace Jobsy.Recruiter.Domain.Repository;

public interface IEmployerProfileRepository
{
    Task AddAsync(EmployerProfile employerProfile);
    Task<bool> ExistsByUserIdAsync(int idUsuario);
    
    // --- AÑADIR ESTOS 3 MÉTODOS ---
    Task<EmployerProfile?> FindByIdAsync(int id);
    void Update(EmployerProfile employerProfile);
    void Remove(EmployerProfile employerProfile);
}