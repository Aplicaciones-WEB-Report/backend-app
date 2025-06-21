using Jobsy.Recruiter.Domain.Model.ValueObjects;
using MediatR;

namespace Jobsy.Recruiter.Domain.Model.Commands;

// Implementa IRequest<int> para decirle a MediatR que devuelve un entero
public record CreateEmployerProfileCommand(
    int Id_Usuario, 
    string CompanyName, 
    CompanySize CompanySize, 
    string? Website, 
    string? Description
) : IRequest<int>;