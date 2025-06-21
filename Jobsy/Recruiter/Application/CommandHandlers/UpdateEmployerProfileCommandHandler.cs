using Jobsy.Recruiter.Domain.Model.Commands;
using Jobsy.Recruiter.Domain.Repository;
using MediatR;

namespace Jobsy.Recruiter.Application.CommandHandlers;

// La definición de la clase debe ser IRequestHandler<UpdateEmployerProfileCommand> o IRequestHandler<UpdateEmployerProfileCommand, Unit>
public class UpdateEmployerProfileCommandHandler : IRequestHandler<UpdateEmployerProfileCommand, Unit>
{
    private readonly IEmployerProfileRepository _employerProfileRepository;

    public UpdateEmployerProfileCommandHandler(IEmployerProfileRepository employerProfileRepository)
    {
        _employerProfileRepository = employerProfileRepository;
    }

    // --- CAMBIO CLAVE ---
    // El método debe devolver Task<Unit>
    public async Task<Unit> Handle(UpdateEmployerProfileCommand request, CancellationToken cancellationToken)
    {
        var employerProfile = await _employerProfileRepository.FindByIdAsync(request.Id);

        if (employerProfile is null)
        {
            throw new ApplicationException($"El perfil de empleador con ID {request.Id} no existe.");
        }

        employerProfile.CompanyName = request.CompanyName;
        employerProfile.CompanySize = request.CompanySize;
        employerProfile.Website = request.Website;
        employerProfile.Description = request.Description;

        _employerProfileRepository.Update(employerProfile);

        // --- AÑADIR ESTA LÍNEA ---
        return Unit.Value;
    }
}