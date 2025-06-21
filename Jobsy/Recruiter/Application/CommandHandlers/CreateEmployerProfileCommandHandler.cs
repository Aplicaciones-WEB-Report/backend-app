using Jobsy.Recruiter.Domain.Model.Aggregates;
using Jobsy.Recruiter.Domain.Model.Commands;
using Jobsy.Recruiter.Domain.Repository;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Jobsy.UserAuthentication.Domain.Model.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Recruiter.Application.CommandHandlers;

public class CreateEmployerProfileCommandHandler : IRequestHandler<CreateEmployerProfileCommand, int>
{
    private readonly IEmployerProfileRepository _employerProfileRepository;
    private readonly AppDbContext _context;

    public CreateEmployerProfileCommandHandler(IEmployerProfileRepository employerProfileRepository, AppDbContext context)
    {
        _employerProfileRepository = employerProfileRepository;
        _context = context;
    }

    public async Task<int> Handle(CreateEmployerProfileCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.CompanyName))
        {
            throw new ArgumentException("El nombre de la compañía no puede estar vacío.", nameof(request.CompanyName));
        }

        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Id_Usuario == request.Id_Usuario, cancellationToken);

        if (user == null)
        {
            throw new ApplicationException($"El usuario con ID {request.Id_Usuario} no existe.");
        }

        if (user.rol != Rol.RECLUTADOR)
        {
            throw new ApplicationException($"El usuario con ID {request.Id_Usuario} no es un reclutador.");
        }

        var profileExists = await _employerProfileRepository.ExistsByUserIdAsync(request.Id_Usuario);
        if (profileExists)
        {
            throw new ApplicationException($"El usuario con ID {request.Id_Usuario} ya tiene un perfil de empleador asociado.");
        }

        var employerProfile = new EmployerProfile
        {
            Id_Usuario = request.Id_Usuario,
            CompanyName = request.CompanyName,
            CompanySize = request.CompanySize,
            Website = request.Website,
            Description = request.Description
        };

        await _employerProfileRepository.AddAsync(employerProfile);
        await _context.SaveChangesAsync(cancellationToken); 

        return employerProfile.Id;
    }
}