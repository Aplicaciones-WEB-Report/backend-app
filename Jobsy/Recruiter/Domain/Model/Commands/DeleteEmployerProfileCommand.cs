using MediatR;

namespace Jobsy.Recruiter.Domain.Model.Commands;

public record DeleteEmployerProfileCommand(int Id) : IRequest;