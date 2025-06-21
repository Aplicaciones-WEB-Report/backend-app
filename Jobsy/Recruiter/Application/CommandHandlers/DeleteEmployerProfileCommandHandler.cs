using Jobsy.Recruiter.Domain.Model.Commands;
using Jobsy.Recruiter.Domain.Repository;
using MediatR;

namespace Jobsy.Recruiter.Application.CommandHandlers;

// La definición de la clase debe ser IRequestHandler<DeleteEmployerProfileCommand> o IRequestHandler<DeleteEmployerProfileCommand, Unit>
public class DeleteEmployerProfileCommandHandler : IRequestHandler<DeleteEmployerProfileCommand, Unit>
{
    private readonly IEmployerProfileRepository _employerProfileRepository;

    public DeleteEmployerProfileCommandHandler(IEmployerProfileRepository employerProfileRepository)
    {
        _employerProfileRepository = employerProfileRepository;
    }

    // --- CAMBIO CLAVE ---
    // El método debe devolver Task<Unit>
    public async Task<Unit> Handle(DeleteEmployerProfileCommand request, CancellationToken cancellationToken)
    {
        var employerProfile = await _employerProfileRepository.FindByIdAsync(request.Id);

        if (employerProfile is null)
        {
            throw new ApplicationException($"El perfil de empleador con ID {request.Id} no existe.");
        }

        _employerProfileRepository.Remove(employerProfile);

        // --- AÑADIR ESTA LÍNEA ---
        return Unit.Value;
    }
}